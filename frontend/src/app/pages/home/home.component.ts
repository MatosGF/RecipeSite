import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../../services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  receitas: any[] = [];

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    this.recipeService.getApprovedRecipes().subscribe((data: any[]) => {
      this.receitas = data;
      console.log(this.receitas);
    });
    this.route.queryParams.subscribe((params) => {
      if (params && Object.keys(params).length > 0) {
        this.loadRecipes(params);
      }
    });
  }

  getStars(rating: number = 0): number[] {
    return Array(Math.round(rating)).fill(0);
  }

  loadRecipes(filters: any) {
    this.recipeService.searchRecipes(filters).subscribe((data: any[]) => {
      this.receitas = data;
    });
  }

  buscar(search: string | null) {
    this.recipeService.searchRecipes({ search }).subscribe((data: any[]) => {
      this.receitas = data;
    });
  }
}
