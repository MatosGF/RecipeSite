import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css'],
})
export class SigninComponent {
  signInForm: FormGroup;
  apiUrl: string = 'https://localhost:7048/api/user';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
  ) {
    this.signInForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.signInForm.invalid) {
      alert('Preencha todos os campos corretamente!');
      return;
    }

    const usuario = this.signInForm.value;

    this.http.post(this.apiUrl, usuario).subscribe({
      next: (res) => {
        alert('Usuário cadastrado com sucesso!');
        this.signInForm.reset();
      },
      error: (err) => {
        console.error('Erro ao cadastrar usuário:', err);

        if (err.status === 400) {
          alert('Dados inválidos! Verifique os campos.');
        } else {
          alert('Erro ao cadastrar usuário!');
        }
      },
    });
  }
}
