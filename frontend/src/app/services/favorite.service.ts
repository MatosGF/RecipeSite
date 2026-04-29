import { Favorite } from './../models/favorite.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root' })
export class FavoriteService {

  private apiUrl = 'https://localhost:7048/api/favorite';

  constructor(private http: HttpClient) {}

  getMyFavorites() {
  return this.http.get<any[]>(`${this.apiUrl}/my`, this.authHeaders());
  }

 toggle(recipeId: number) {
  return this.http.post<any>(`${this.apiUrl}/toggle/${recipeId}`,{},
    this.authHeaders()
  );
}

  isFavorite(recipeId: number) {
    return this.http.get<boolean>(`${this.apiUrl}/is-favorite/${recipeId}`, this.authHeaders());
  }

  private authHeaders() {
    const token = localStorage.getItem('token');
    return {
      headers: { Authorization: `Bearer ${token}` }
    };
  }

}

