import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rating } from '../models/rating.model';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  private apiUrl = 'https://localhost:7048/api/rating';

  constructor(private http: HttpClient) {}

  criarAvaliacao(rating: Rating): Observable<any> {
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    return this.http.post(this.apiUrl, rating, { headers });
  }

  getMediaPorReceita(recipeId: number): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/recipe/${recipeId}/average`);
  }

  getMyRating(recipeId: number) {
  const token = localStorage.getItem('token');

  const headers = new HttpHeaders({
    Authorization: `Bearer ${token}`
  });

  return this.http.get<any>(`${this.apiUrl}/recipe/${recipeId}/my`, { headers });
  }

}

