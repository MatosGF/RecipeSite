export interface Recipe {
  id: number;
  title: string;
  description: string;
  preparationTime: string;
  imageUrl: string;
  status: string;

  category?: {
    id: number;
    name: string;
  };

  difficulty?: {
    id: number;
    name: string;
  };

  user?: {
    id: number;
    name: string;
  };

  recipeIngredients: {
    amount: number;
    ingredient?: { name: string };
    measurementType?: { name: string };
  }[];

  averageRating?: number;
}




