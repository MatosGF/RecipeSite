import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private baseUrl = 'https://localhost:7048/api/recipe';

  constructor(private http: HttpClient) {}

  getCategorias(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/categories`);
  }

  getDificuldades(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/difficulties`);
  }

  getIngredientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/ingredients`);
  }

  getMedidas(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7048/api/measurementtype');
  }

  getApprovedRecipes() {
  return this.http.get<any[]>(`${this.baseUrl}/approved`);
  }

  getRecipeById(id: number) {
  return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  getReceitasDoUsuario(userId: number): Observable<any[]> {
  const token = localStorage.getItem('token');

  const headers = {
    Authorization: `Bearer ${token}`
  };

  return this.http.get<any[]>(
    `https://localhost:7048/api/recipe/user/${userId}`,
    { headers }
  );
  }


  createRecipe(recipe: any) {
  const token = localStorage.getItem('token');

  const headers = {
    'Authorization': `Bearer ${token}`
  };

  return this.http.post(`${this.baseUrl}`, recipe, { headers });
  }


  getPendingRecipes() {
  return this.http.get<any[]>('https://localhost:7048/api/recipe/pending', {
    headers: this.getAuthHeaders()
  });
  }

  deleteReceita(id: number): Observable<void> {
  const token = localStorage.getItem('token');
  const headers = { Authorization: `Bearer ${token}` };

  return this.http.delete<void>(
    `https://localhost:7048/api/recipe/${id}`,
    { headers }
  );
 }

  updateReceita(id: number, receita: any): Observable<any> {
  const token = localStorage.getItem('token');

  const headers = {
    Authorization: `Bearer ${token}`
  };

  return this.http.put<any>(
    `https://localhost:7048/api/recipe/${id}`,
    receita,
    { headers }
  );
  }

  approveRecipe(id: number) {
  return this.http.put(
    `https://localhost:7048/api/recipe/${id}/approve`,
    {},
    { headers: this.getAuthHeaders() }
  );
  }

  private getAuthHeaders() {
  const token = localStorage.getItem('token');
  return { Authorization: `Bearer ${token}` };
  }

  uploadImage(file: File): Observable<{ imageUrl: string }> {
  const formData = new FormData();
  formData.append('file', file);

  const token = localStorage.getItem('token');

  const headers = {
    Authorization: `Bearer ${token}`
  };

  return this.http.post<{ imageUrl: string }>(
    `${this.baseUrl}/upload-image`,
    formData,
    { headers }
  );
  }

  searchRecipes(params: any) {
  return this.http.get<any[]>(
    `https://localhost:7048/api/recipe/search`,
    { params }
  );
}
}


