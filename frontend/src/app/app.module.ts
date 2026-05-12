import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { SigninComponent } from './signin/signin.component';
import { LoggedComponent } from './logged/logged.component';
import { AdminComponent } from './admin/admin.component';
import { UserinformationComponent } from './userinformation/userinformation.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SigninComponent,
    LoginComponent,
    LoggedComponent,
    AdminComponent,
    UserinformationComponent,
    RecipeDetailsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
