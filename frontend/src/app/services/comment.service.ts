import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Comment } from '../models/comment.model';

@Injectable({ providedIn: 'root' })
export class CommentService {

  private apiUrl = 'https://localhost:7048/api/comment';

  constructor(private http: HttpClient) {}

  getByRecipe(recipeId: number) {
    return this.http.get<any[]>(`${this.apiUrl}/recipe/${recipeId}`);
  }

  create(comment: any) {
    const token = localStorage.getItem('token');
    return this.http.post(this.apiUrl, comment, {
      headers: { Authorization: `Bearer ${token}` }
    });
  }

  
}


