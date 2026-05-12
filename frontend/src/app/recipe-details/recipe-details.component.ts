import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service.service';
import { RatingService } from '../services/rating.service';
import { RecipeService } from '../services/recipe.service';
import { CommentService } from '../services/comment.service';
import { FavoriteService } from '../services/favorite.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css'],
})
export class RecipeDetailsComponent implements OnInit {
  receita: any;
  isLoggedIn = false;
  averageRating = 0;
  userRating = 0;
  hoverRating = 0;
  comments: any[] = [];
  newComment = '';
  isFavorite = false;
  isFavorited = false;

  constructor(
    private route: ActivatedRoute,
    private recipeService: RecipeService,
    private ratingService: RatingService,
    private authService: AuthService,
    private commentService: CommentService,
    private favoriteService: FavoriteService,
  ) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();

    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!id) return;

    this.carregarReceita(id);
    this.carregarMedia(id);

    if (this.isLoggedIn) {
      this.favoriteService.isFavorite(id).subscribe((res) => {
        this.isFavorite = res;
      });

      this.ratingService.getMyRating(id).subscribe((res) => {
        if (res) {
          this.userRating = res.ratingValue;
        }
      });
    }
  }

  carregarReceita(id: number): void {
    this.recipeService.getRecipeById(id).subscribe((res) => {
      this.receita = res;
      this.carregarComentarios();
    });
  }

  carregarComentarios(): void {
    this.commentService.getByRecipe(this.receita.id).subscribe((res) => {
      this.comments = res;
    });
  }

  toggleFavorito(): void {
    this.favoriteService.toggle(this.receita.id).subscribe({
      next: (res) => {
        this.isFavorite = res.isFavorite;
      },
      error: (err) => {
        console.error('Erro ao favoritar:', err);
      },
    });
  }

  addComment(): void {
    if (!this.isLoggedIn) {
      alert('Faça login para comentar.');
      return;
    }
    if (!this.newComment.trim()) return;
    const payload = {
      recipeId: this.receita.id,
      comments: this.newComment,
    };

    this.commentService.create(payload).subscribe(() => {
      this.newComment = '';
      this.carregarComentarios();
    });
  }

  carregarMedia(recipeId: number): void {
    this.ratingService.getMediaPorReceita(recipeId).subscribe((media) => {
      this.averageRating = media;
    });
  }

  verificarFavorito(): void {
    if (!this.isLoggedIn) return;

    this.favoriteService.isFavorite(this.receita.id).subscribe((res) => {
      this.isFavorite = res;
    });
  }

  rateRecipe(value: number): void {
    if (!this.isLoggedIn || !this.receita) return;

    const rating = {
      ratingValue: value,
      recipeId: this.receita.id,
    };

    this.ratingService.criarAvaliacao(rating).subscribe(() => {
      this.userRating = value;
      this.carregarMedia(this.receita.id);
    });
  }

  getStarFill(index: number): number {
    const rating = this.hoverRating || this.averageRating;
    const diff = rating - index;
    if (diff >= 1) return 100;
    if (diff > 0) return diff * 100;
    return 0;
  }
}
