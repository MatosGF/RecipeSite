import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Ingredient {
  id: number;
  isAtive: boolean;
  name: string;
  editing?: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  private apiUrl = 'https://localhost:7048/api/Ingredient';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(this.apiUrl);
  }

  create(item: Ingredient): Observable<Ingredient> {
    return this.http.post<Ingredient>(this.apiUrl, item);
  }

  update(id: number, item: Ingredient): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, item);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  search(name: string): Observable<Ingredient[]> {
  return this.http.get<Ingredient[]>(`${this.apiUrl}/search?name=${name}`);
  }
}

