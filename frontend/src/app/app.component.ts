import { Component } from '@angular/core';
import { AuthService } from './services/auth.service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  menuOpen = false;
  searchText: string = '';

  title(title: any) {
    throw new Error('Method not implemented.');
  }
  constructor(
    public authService: AuthService,
    private router: Router,
  ) {}

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  getUserName(): string | null {
    return this.authService.getUserName();
  }

  get isAdmin(): boolean {
    const role = this.authService.getUserRole();
    return role?.toLowerCase() === 'admin';
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  toggleMenu(): void {
    this.menuOpen = !this.menuOpen;
  }

  goToProfile(): void {
    this.menuOpen = false;
    this.router.navigate(['/perfil']);
  }

  goToActivity(): void {
    this.menuOpen = false;
    const role = this.authService.getUserRole();

    if (role?.toLowerCase() === 'admin') {
      this.router.navigate(['/admin']);
    } else {
      this.router.navigate(['/logged']);
    }
  }

  buscar() {
    if (!this.searchText.trim()) return;

    this.router.navigate(['/'], {
      queryParams: { search: this.searchText },
    });
  }
}
