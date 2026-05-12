import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Difficulty {
  id: number;
  isAtive: boolean;
  name: string;
  editing?: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class DifficultyService {
  private apiUrl = 'https://localhost:7048/api/Difficulty';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Difficulty[]> {
    return this.http.get<Difficulty[]>(this.apiUrl);
  }

  create(item: Difficulty): Observable<Difficulty> {
    return this.http.post<Difficulty>(this.apiUrl, item);
  }

  update(id: number, item: Difficulty): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, item);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
