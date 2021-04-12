import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'category/all/news'},
      { path: 'category/:categoryId/news', loadChildren: () => import('./news/news-routing.module').then(m => m.NewsRoutingModule) },
      { path: 'about', loadChildren: () => import('./about/about-routing.module').then(m => m.AboutRoutingModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
