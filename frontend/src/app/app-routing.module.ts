import { AuthGuard } from './services/auth.guard.service';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './login/login.component';
import { SigninComponent } from './signin/signin.component';
import { LoggedComponent } from './logged/logged.component';
import { AdminComponent } from './admin/admin.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { UserinformationComponent } from './userinformation/userinformation.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'logged', component: LoggedComponent, canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'recipe/:id', component: RecipeDetailsComponent },
  {
    path: 'perfil',
    component: UserinformationComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
