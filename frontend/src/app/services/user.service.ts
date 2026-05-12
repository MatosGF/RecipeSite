import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:7048/api/user';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    const body = { email, password };
    return this.http.post<any>(`${this.apiUrl}/login`, body);
  }

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  blockUser(id: number) {
    return this.http.post(`${this.apiUrl}/${id}/lock`, {});
  }

  unblockUser(id: number) {
    return this.http.post(`${this.apiUrl}/${id}/unlock`, {});
  }

  searchUsers(term: string) {
    return this.http.get<User[]>(`${this.apiUrl}/search?name=${term}`);
  }

  getMe() {
    const token = localStorage.getItem('token');

    const headers = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };

    return this.http.get<any>(`${this.apiUrl}/me`, headers);
  }

  updateMe(data: any) {
    const token = localStorage.getItem('token');

    const headers = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };

    return this.http.put(`${this.apiUrl}/me`, data, headers);
  }
}
