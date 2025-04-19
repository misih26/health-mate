import { Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { AppComponent } from './app.component';

export const routes: Routes = [
    {path:"categories",component:CategoriesComponent},
    {path:"",component:AppComponent}
];
