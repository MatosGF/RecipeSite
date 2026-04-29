import { RecipeIngredient } from './../models/recipe-ingredient.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class RecipeService extends BaseService<RecipeIngredient> {
  constructor(http: HttpClient) {
    super(http, 'https://localhost:5001/api/RecipeIngredient');
  }
}
