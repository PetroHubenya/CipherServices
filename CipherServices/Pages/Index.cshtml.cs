using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CipherServices.Services;
using CipherServices.Data;
using CipherServices.Models;

namespace CipherServices.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, string> Secrets { get; set; }

        [BindProperty]
        public Message NewMessage { get; set; }

        private readonly IDecrypter _decrypter;

        private readonly IEncrypter _encrypter;

        private readonly MessageContext _context;

        public IndexModel(IDecrypter decrypter, IEncrypter encrypter, MessageContext context)
        {
            _decrypter = decrypter;
            _encrypter = encrypter;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Secrets = new Dictionary<string, string>();
            await LoadSecretsAsync(_decrypter, _context);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // “Clean” the NewMessage.Text property using Trim() and ToLower()
                string text = NewMessage.Text;
                string cleanedText = text.Trim().ToLower();
                // Encrypt that cleaned message using your IEncrypter service’s Encrypt() method.
                string encryptedText = _encrypter.Encrypt(cleanedText);
                Message m = new Message { Text = encryptedText };
                _context.Messages.Add(m);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                await LoadSecretsAsync(_decrypter, _context);
                return Page();
            }

        }

        private async Task LoadSecretsAsync(IDecrypter decrypter, MessageContext context)
        {
            Secrets = new Dictionary<string, string>();
            var messages = await context.Messages.ToListAsync();

            foreach (Message m in messages)
            {
                Secrets.TryAdd(m.Text, decrypter.Decrypt(m.Text));
            }
        }
    }
}
