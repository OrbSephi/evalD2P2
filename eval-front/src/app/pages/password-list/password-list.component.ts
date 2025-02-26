import { Component, OnInit } from '@angular/core';
import { PasswordService } from '../../services/password.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-password-list',
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.css'],
  imports: [CommonModule],
})
export class PasswordListComponent implements OnInit {
  passwords: any[] = [];

  constructor(private passwordService: PasswordService) {}

  ngOnInit(): void {
    // Récupérer les mots de passe
    this.passwordService.getPasswords().subscribe((data) => {
      this.passwords = data;
    });
  }

  // Méthode pour supprimer un mot de passe en fonction de l'applicationId
  deletePassword(applicationId: number): void {
    this.passwordService.deletePassword(applicationId).subscribe(() => {
      this.passwords = this.passwords.filter(
        (password) => password.applicationId !== applicationId
      );
    });
  }
}
