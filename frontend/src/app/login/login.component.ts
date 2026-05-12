import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  logInForm!: FormGroup;
  submitted = false;
  erroLogin: string = '';

  constructor(
    public fb: FormBuilder,
    public userService: UserService,
    public router: Router,
  ) {}

  ngOnInit(): void {
    this.logInForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.logInForm.invalid) {
      if (this.logInForm.controls['email'].errors) {
        alert('Email inválido!');
      } else if (this.logInForm.controls['password'].errors) {
        alert('Senha inválida!');
      }
      return;
    }

    const { email, password } = this.logInForm.value;

    this.userService.login(email, password).subscribe({
      next: (res: any) => {
        localStorage.setItem('token', res.token);

        const decoded: any = jwtDecode(res.token);
        localStorage.setItem('userId', decoded.userId);

        const role = decoded.role;

        if (role === 'admin') {
          this.router.navigate(['/admin']);
        } else {
          this.router.navigate(['/logged']);
        }
      },
      error: (err) => {
        alert('Email ou senha inválidos!');
      },
    });
  }

  navegatetosignin(): void {
    this.router.navigate(['/signin']);
  }
}
