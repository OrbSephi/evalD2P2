import { Routes } from '@angular/router';
import { PasswordListComponent } from './pages/password-list/password-list.component';
import { AddPasswordComponent } from './pages/password-add/password-add.component';
import { ApplicationListComponent } from './pages/application-list/application-list.component';

export const routes: Routes = [
  { path: '', redirectTo: '/passwords', pathMatch: 'full' },
  { path: 'passwords', component: PasswordListComponent },
  { path: 'add-password', component: AddPasswordComponent },
  { path: 'applications', component: ApplicationListComponent },
  { path: '**', redirectTo: '/passwords' },
];
