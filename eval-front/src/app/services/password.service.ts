import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PasswordService {
  private apiUrl = 'http://localhost:5039/api';
  private apiKey = 'ceciestlacledelapi';

  constructor(private http: HttpClient) {}

  getApplications(): Observable<any> {
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${this.apiKey}`
    );
    return this.http.get<any[]>(`${this.apiUrl}/Application`, { headers });
  }

  getPasswords(): Observable<any> {
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${this.apiKey}`
    );
    return this.http.get<any[]>(`${this.apiUrl}/Password`, { headers });
  }

  addPassword(passwordData: any): Observable<any> {
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${this.apiKey}`
    );
    return this.http.post<any>(`${this.apiUrl}/passwords`, passwordData, {
      headers,
    });
  }

  deletePassword(id: number): Observable<any> {
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${this.apiKey}`
    );
    return this.http.delete<any>(`${this.apiUrl}/passwords/${id}`, { headers });
  }
}
