import { FavoriteService } from './../services/favorite.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { RecipeService } from '../services/recipe.service';
import { jwtDecode } from 'jwt-decode';
import { ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logged',
  templateUrl: './logged.component.html',
  styleUrls: ['./logged.component.css'],
})
export class LoggedComponent implements OnInit {
  @ViewChild('fileInput') fileInput!: ElementRef<HTMLInputElement>;

  recipeForm!: FormGroup;
  minhasReceitas: any[] = [];
  dificuldades: any[] = [];
  categorias: any[] = [];
  ingredientes: any[] = [];
  medidas: any[] = [];
  selectedFile?: File;
  ingredientesAdicionados: any[] = [];
  userId: number = 0;
  editandoReceita: any = null;
  isUploadingImage: boolean = false;
  imageUrl: string = '';
  favorites: any[] = [];

  private getUserIdFromToken(): number {
    const token = localStorage.getItem('token');
    if (!token) return 0;

    const decoded: any = jwtDecode(token);
    return Number(decoded.userId);
  }

  constructor(
    private fb: FormBuilder,
    private recipeService: RecipeService,
    private favoriteService: FavoriteService,
    public router: Router,
  ) {}

  ngOnInit(): void {
    this.recipeForm = this.fb.group({
      titulo: ['', Validators.required],
      ingredientes: this.fb.array([]),
      metodoPreparo: [''],
      categoria: ['', Validators.required],
      dificuldade: ['', Validators.required],
      tempoPreparo: ['', Validators.required],
      imageUrl: [''],
    });

    this.userId = this.getUserIdFromToken();

    if (!this.userId) {
      console.error('UserId inválido');
      return;
    }

    this.carregarMinhasReceitas();
    this.addIngrediente();
    this.carregarListas();
    this.carregarFavoritos();
  }

  carregarListas(): void {
    this.recipeService
      .getDificuldades()
      .subscribe((data) => (this.dificuldades = data));
    this.recipeService
      .getCategorias()
      .subscribe((data) => (this.categorias = data));
    this.recipeService
      .getIngredientes()
      .subscribe((data) => (this.ingredientes = data));
    this.recipeService.getMedidas().subscribe((data) => (this.medidas = data));
  }

  get ingredientesArray(): FormArray {
    return this.recipeForm.get('ingredientes') as FormArray;
  }

  ingredienteForm = this.fb.group({
    ingredientId: [''],
    measurementTypeId: [''],
    amount: [''],
  });

  addIngrediente() {
    const form = this.ingredienteForm.value;

    if (!form.ingredientId || !form.measurementTypeId || !form.amount) return;

    const ingredienteNome =
      this.ingredientes.find((i) => i.id == form.ingredientId)?.name || '';
    const medidaNome =
      this.medidas.find((m) => m.id == form.measurementTypeId)?.name || '';

    this.ingredientesAdicionados.push({
      ingredientId: Number(form.ingredientId),
      measurementTypeId: Number(form.measurementTypeId),
      amount: Number(form.amount),
      ingredienteNome,
      medidaNome,
    });

    this.ingredienteForm.reset();
  }

  removerIngrediente(index: number): void {
    this.ingredientesAdicionados.splice(index, 1);
  }

  getIngredienteNome(id: number) {
    return this.ingredientes.find((x) => x.id === id)?.name || '';
  }

  getMedidaNome(id: number) {
    return this.medidas.find((x) => x.id === id)?.name || '';
  }

  carregarMinhasReceitas() {
    this.recipeService.getReceitasDoUsuario(this.userId).subscribe({
      next: (data) => {
        this.minhasReceitas = Array.isArray(data) ? data : [];
      },
      error: (err) => console.error(err),
    });
  }

  carregarFavoritos() {
    this.favoriteService.getMyFavorites().subscribe((res: any) => {
      this.favorites = Array.isArray(res)
        ? res
        : Array.isArray(res.favorites)
          ? res.favorites
          : [];
      console.log(this.favorites);
    });
  }

  deletarReceita(id: number) {
    if (!confirm('Tem certeza que deseja excluir esta receita?')) return;

    this.recipeService.deleteReceita(id).subscribe({
      next: () => {
        this.minhasReceitas = this.minhasReceitas.filter((r) => r.id !== id);
      },
      error: (err) => console.error('Erro ao excluir receita:', err),
    });
  }

  editarReceita(receita: any) {
    this.editandoReceita = receita;

    this.recipeForm.patchValue({
      titulo: receita.title,
      metodoPreparo: receita.description,
      categoria: receita.categoryId,
      dificuldade: receita.difficultyId,
      tempoPreparo: receita.preparationTime,
    });

    this.ingredientesAdicionados = receita.recipeIngredients.map((ri: any) => ({
      ingredientId: ri.ingredientId,
      measurementTypeId: ri.measurementTypeId,
      amount: ri.amount,
      ingredienteNome: ri.ingredient?.name || '',
      medidaNome: ri.measurementType?.name || '',
    }));
  }

  cancelarEdicao() {
    this.editandoReceita = null;
    this.recipeForm.reset();
    this.ingredientesAdicionados = [];

    this.imageUrl = '';
    this.selectedFile = undefined!;

    if (this.fileInput) {
      this.fileInput.nativeElement.value = '';
    }
  }

  salvarEdicao() {
    if (!this.editandoReceita) return;

    const formValue = this.recipeForm.value;

    const receitaAtualizada = {
      id: this.editandoReceita.id,
      title: formValue.titulo,
      description: formValue.metodoPreparo,
      preparationTime: String(formValue.tempoPreparo),
      categoryId: Number(formValue.categoria),
      difficultyId: Number(formValue.dificuldade),
      imageUrl: this.imageUrl || this.editandoReceita.imageUrl,
      recipeIngredients: this.ingredientesAdicionados.map((i) => ({
        ingredientId: i.ingredientId,
        measurementTypeId: i.measurementTypeId,
        amount: i.amount,
      })),
    };

    this.recipeService
      .updateReceita(this.editandoReceita.id, receitaAtualizada)
      .subscribe({
        next: () => {
          const index = this.minhasReceitas.findIndex(
            (r) => r.id === this.editandoReceita.id,
          );

          if (index !== -1) {
            this.minhasReceitas[index] = {
              ...this.minhasReceitas[index],
              ...receitaAtualizada,
            };
          }

          this.cancelarEdicao();
          this.imageUrl = '';
          this.selectedFile = undefined!;
          this.fileInput.nativeElement.value = '';
        },
        error: (err) => console.error('Erro ao atualizar receita:', err),
      });
  }

  onFileSelected(event: any) {
    const file = event.target.files?.[0];

    if (!file) {
      alert('Nenhum arquivo selecionado.');
      return;
    }

    this.selectedFile = file;
    this.isUploadingImage = true;
    this.imageUrl = '';

    this.recipeService.uploadImage(file).subscribe({
      next: (res) => {
        this.isUploadingImage = false;
        this.imageUrl = res.imageUrl;
      },
      error: (err) => {
        this.isUploadingImage = false;
        console.error('Erro ao enviar imagem:', err);
        alert('Falha ao enviar imagem.');
      },
    });
  }

  onSubmit(): void {
    if (this.editandoReceita) {
      return;
    }
    if (this.recipeForm.invalid) {
      this.recipeForm.markAllAsTouched();
      return;
    }
    if (this.isUploadingImage) {
      alert('Aguarde o upload da imagem terminar antes de enviar.');
      return;
    }
    if (!this.imageUrl) {
      alert('Você deve enviar uma imagem antes de salvar a receita.');
      return;
    }

    const token = localStorage.getItem('token');
    if (!token) {
      alert('Você precisa estar logado.');
      return;
    }

    const ingredientes = this.ingredientesAdicionados.map((i) => ({
      ingredientId: i.ingredientId,
      measurementTypeId: i.measurementTypeId,
      amount: Number(i.amount),
    }));

    const recipeDto = {
      title: this.recipeForm.value.titulo,
      description: this.recipeForm.value.metodoPreparo,
      preparationTime: String(this.recipeForm.value.tempoPreparo),
      categoryId: Number(this.recipeForm.value.categoria),
      difficultyId: Number(this.recipeForm.value.dificuldade),
      imageUrl: this.imageUrl,
      recipeIngredients: ingredientes,
    };

    this.recipeService.createRecipe(recipeDto).subscribe({
      next: () => {
        alert('Receita enviada com sucesso!');

        this.recipeForm.reset();
        this.imageUrl = '';
        this.selectedFile = undefined!;
        this.ingredientesAdicionados = [];

        this.carregarMinhasReceitas();
      },
      error: (err) => {
        console.error('Erro ao criar receita:', err);
        alert('Erro ao criar receita.');
      },
    });
  }
}
