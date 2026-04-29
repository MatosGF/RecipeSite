import { Component, OnInit } from '@angular/core';
import { RecipeService } from 'src/app/services/recipe.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  receitas: any[] = [];

  constructor(private recipeService: RecipeService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.recipeService.getApprovedRecipes().subscribe(data => {
      this.receitas = data;
    });
    this.route.queryParams.subscribe(params => {
    this.loadRecipes(params);
  });
  }

  getStars(rating: number = 0): number[] {
    return Array(Math.round(rating)).fill(0);
  }

  loadRecipes(filters: any) {
  this.recipeService.searchRecipes(filters)
    .subscribe(data => {
      this.receitas = data;
    });
  }

  buscar(search: string | null) {
  this.recipeService.searchRecipes({ search })
    .subscribe(data => {
      this.receitas = data;
    });
  }
}

