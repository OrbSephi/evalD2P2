import { Component } from '@angular/core';
import { PasswordService } from '../../services/password.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-password',
  templateUrl: './add-password.component.html',
  styleUrls: ['./add-password.component.css'],
  providers: [PasswordService],
  imports: [CommonModule, HttpClientModule],
})
export class AddPasswordComponent {
  name: string = '';
  applicationId: string = '';
  password: string = '';
  applications: any[] = [];
  appType: string = 'Grand public';

  constructor(private passwordService: PasswordService) {}

  ngOnInit(): void {
    this.passwordService.getApplications().subscribe((data) => {
      this.applications = data;
    });
  }

  addPassword(): void {
    const passwordData = {
      name: this.name,
      applicationId: this.applicationId,
      appType: this.appType,
      password: this.password,
    };

    this.passwordService.addPassword(passwordData).subscribe(() => {
      // Redirection ou affichage d'un message de succès
    });
  }
}
