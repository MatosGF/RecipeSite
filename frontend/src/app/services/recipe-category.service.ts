import { RecipeCategory } from './../models/recipe-category.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class RecipeService extends BaseService<RecipeCategory> {
  constructor(http: HttpClient) {
    super(http, 'https://localhost:5001/api/RecipeCategory');
  }
}
