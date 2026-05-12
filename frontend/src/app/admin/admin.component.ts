import { Component, OnInit } from '@angular/core';
import { CategoryService, Category } from '../services/category.service';
import { IngredientService, Ingredient } from '../services/ingredient.service';
import { DifficultyService, Difficulty } from '../services/difficulty.service';
import { UserService } from '../services/user.service';
import { RecipeService } from '../services/recipe.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FavoriteService } from '../services/favorite.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  categories: Category[] = [];
  ingredients: Ingredient[] = [];
  difficulties: Difficulty[] = [];
  users: any[] = [];
  receitasPendentes: any[] = [];
  favorites: any[] = [];
  filteredIngredients: Ingredient[] = [];

  newCategory: string = '';
  newIngredient: string = '';
  newDifficulty: string = '';
  searchTerm: string = '';
  erroMsg = '';
  ingredientSearch: string = '';
  ingredientError = '';
  categoryError = '';
  difficultyError = '';

  showIngredients = false;
  showCategory = false;
  showDifficulties = false;
  searchDone = false;
  carregando = false;

  constructor(
    private categoryService: CategoryService,
    private ingredientService: IngredientService,
    private difficultyService: DifficultyService,
    private userService: UserService,
    private recipeService: RecipeService,
    private favoriteService: FavoriteService,
    public router: Router,
  ) {}

  ngOnInit(): void {
    this.loadAll();
    this.carregarPendentes();
    this.carregarFavoritos();
  }

  loadAll() {
    this.categoryService.getAll().subscribe((data) => (this.categories = data));
    this.difficultyService
      .getAll()
      .subscribe((data) => (this.difficulties = data));
    this.userService.getUsers().subscribe((data) => (this.users = data));
  }

  carregarFavoritos() {
    this.favoriteService.getMyFavorites().subscribe((res: any) => {
      console.log('FAVORITOS:', res);

      this.favorites = Array.isArray(res)
        ? res
        : Array.isArray(res.favorites)
          ? res.favorites
          : [];
    });
  }

  carregarPendentes(): void {
    this.carregando = true;
    this.recipeService.getPendingRecipes().subscribe({
      next: (data) => {
        this.receitasPendentes = data;
        this.carregando = false;
      },
      error: (err: HttpErrorResponse) => {
        this.erroMsg = err.error || 'Erro ao carregar receitas pendentes.';
        this.carregando = false;
      },
    });
  }

  buscarIngredientes() {
    if (!this.ingredientSearch.trim()) {
      this.filteredIngredients = [];
      return;
    }
    this.ingredientService.search(this.ingredientSearch).subscribe((data) => {
      this.filteredIngredients = data;
    });
  }

  aprovarReceita(id: number): void {
    if (!confirm('Tem certeza que deseja aprovar esta receita?')) return;

    this.recipeService.approveRecipe(id).subscribe({
      next: () => {
        this.receitasPendentes = this.receitasPendentes.filter(
          (r) => r.id !== id,
        );
      },
      error: (err) => {
        console.error('Erro ao aprovar receita:', err);
        alert('Erro ao aprovar receita.');
      },
    });
  }

  addCategory() {
    if (!this.newCategory.trim()) return;
    const item: Category = { id: 0, isAtive: true, name: this.newCategory };
    this.categoryService.create(item).subscribe((created) => {
      this.categories.push(created);
      this.newCategory = '';
    });
  }

  editCategory(cat: Category) {
    cat['editing'] = true;
  }

  saveCategory(cat: Category) {
    this.categoryService.update(cat.id, cat).subscribe(() => {
      cat['editing'] = false;
    });
  }

  deleteCategory(id: number) {
    this.categoryError = '';
    this.categoryService.delete(id).subscribe({
      next: () => {
        this.loadAll();
      },

      error: (err) => {
        console.error(err);

        this.categoryError = err.error;

        setTimeout(() => {
          this.categoryError = '';
        }, 4000);
      },
    });
  }

  addIngredient() {
    if (!this.newIngredient.trim()) return;
    const item: Ingredient = { id: 0, isAtive: true, name: this.newIngredient };
    this.ingredientService.create(item).subscribe((created) => {
      this.ingredients.push(created);
      this.newIngredient = '';
    });
  }

  editIngredient(ing: Ingredient) {
    ing['editing'] = true;
  }

  saveIngredient(ing: Ingredient) {
    this.ingredientService.update(ing.id, ing).subscribe(() => {
      ing['editing'] = false;
    });
  }

  deleteIngredient(id: number) {
    this.ingredientError = '';
    this.ingredientService.delete(id).subscribe({
      next: () => {
        this.filteredIngredients = this.filteredIngredients.filter(
          (i) => i.id !== id,
        );
        this.ingredients = this.ingredients.filter((i) => i.id !== id);
      },
      error: (err) => {
        this.ingredientError = err.error;

        setTimeout(() => {
          this.ingredientError = '';
        }, 4000);
      },
    });
  }

  addDifficulty() {
    if (!this.newDifficulty.trim()) return;
    const item: Difficulty = { id: 0, isAtive: true, name: this.newDifficulty };
    this.difficultyService.create(item).subscribe((created) => {
      this.difficulties.push(created);
      this.newDifficulty = '';
    });
  }

  editDifficulty(dif: Difficulty) {
    dif['editing'] = true;
  }

  saveDifficulty(dif: Difficulty) {
    this.difficultyService.update(dif.id, dif).subscribe(() => {
      dif['editing'] = false;
    });
  }

  deleteDifficulty(id: number) {
    this.difficultyError = '';
    this.difficultyService.delete(id).subscribe({
      next: () => {
        this.loadAll();
      },
      error: (err) => {
        console.error(err);
        this.difficultyError = err.error;
        setTimeout(() => {
          this.difficultyError = '';
        }, 4000);
      },
    });
  }

  searchUsers(): void {
    this.searchDone = true;

    if (!this.searchTerm.trim()) {
      this.users = [];
      return;
    }

    this.userService.searchUsers(this.searchTerm).subscribe((data) => {
      this.users = data;
    });
  }

  blockUser(id: number): void {
    this.userService.blockUser(id).subscribe({
      next: () => {
        this.searchUsers();
      },
      error: (err) => console.error('Erro ao bloquear usuário:', err),
    });
  }
  unblockUser(id: number): void {
    this.userService.unblockUser(id).subscribe(() => this.searchUsers());
  }

  excluirReceita(id: number): void {
    if (!confirm('Tem certeza que deseja excluir esta receita?')) return;

    this.recipeService.deleteReceita(id).subscribe({
      next: () => {
        this.receitasPendentes = this.receitasPendentes.filter(
          (r: { id: number }) => r.id !== id,
        );
      },
      error: (err: any) => {
        console.error('Erro ao excluir receita:', err);
        alert('Erro ao excluir receita.');
      },
    });
  }
}
