﻿using System.ComponentModel.DataAnnotations;

namespace ApiEvalD2P2P3.Entities
{
    public class PasswordEntity
    {
        [Key]
        public int Id { get; set; }
        public string EncryptedPassword { get; set; } = string.Empty;

        // Clé étrangère pour la relation avec ApplicationEntity
        public int ApplicationId { get; set; }

        // Navigation vers l'entité ApplicationEntity
        public ApplicationEntity Application { get; set; } = null!;
    }
}