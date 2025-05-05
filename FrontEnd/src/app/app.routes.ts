import { Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { RecepiesComponent } from './recepies/recepies.component';
import { CategoryModifyComponent } from './category-modify/category-modify.component';
import { DiagramsComponent } from './diagrams/diagrams.component';
import { NotFoundComponent } from './not-found/not-found.component';

export const routes: Routes = [
    {path:"categories",component:CategoriesComponent},
    {path:"",component:MainPageComponent},
    {path:"recipes", component:RecepiesComponent},
    {path:"category-modify/:id", component:CategoryModifyComponent},
    {path:"diagrams", component:DiagramsComponent},
    {path:"**", component:NotFoundComponent}

];
