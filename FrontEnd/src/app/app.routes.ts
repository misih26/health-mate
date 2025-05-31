import { Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { RecepiesComponent } from './recepies/recepies.component';
import { CategoryModifyComponent } from './category-modify/category-modify.component';
import { DiagramsComponent } from './diagrams/diagrams.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CategoryFilterComponent } from './category-filter/category-filter.component';
import { NewRecipeComponent } from './new-recipe/new-recipe.component';
import { NewCategoryComponent } from './new-category/new-category.component';

export const routes: Routes = [
    { path: "categories", component: CategoriesComponent },
    { path: "", component: MainPageComponent },
    { path: "recipes", component: RecepiesComponent },
    { path: "category-modify/:id", component: CategoryModifyComponent },
    { path: "diagrams", component: DiagramsComponent },
    { path: "category-by-name/:name", component: CategoryFilterComponent },
    { path: "new-recipe", component: NewRecipeComponent },
    { path: "new-category", component: NewCategoryComponent },
    { path: "**", component: NotFoundComponent }

];
