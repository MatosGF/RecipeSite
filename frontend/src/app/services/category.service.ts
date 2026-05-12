import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Category {
  id: number;
  isAtive: boolean;
  name: string;
  editing?: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'https://localhost:7048/api/Category';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  create(item: Category): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, item);
  }

  update(id: number, item: Category): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, item);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
