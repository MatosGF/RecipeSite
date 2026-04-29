import  { Favorite } from './favorite.model';
import { Recipe } from './recipe.model';

export interface User {
  name: string;
  email: string;
  password: string;
  isRegistered: boolean;
  isBlocked: boolean;
  isAdmin: boolean;
  recipes: Recipe[];
  favorites: Favorite[];
}

