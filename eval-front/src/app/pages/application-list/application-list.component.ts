import { Component, OnInit } from '@angular/core';
import { PasswordService } from '../../services/password.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css'],
  providers: [PasswordService],
  imports: [CommonModule, HttpClientModule],
})
export class ApplicationListComponent implements OnInit {
  applications: any[] = [];

  constructor(private passwordService: PasswordService) {}

  ngOnInit(): void {
    this.passwordService.getApplications().subscribe((data) => {
      this.applications = data;
    });
  }
}
