import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'category/0/news'},
      { path: 'category/:categoryId/news', loadChildren: () => import('./news/news.module').then(m => m.NewsModule) },
      { path: 'news/search/:search', loadChildren: () => import('./news/news.module').then(m => m.NewsModule) },
      { path: 'about', loadChildren: () => import('./about/about.module').then(m => m.AboutModule) },
      { path: 'news/:newsItemId', loadChildren: () => import('./news-item/news-item.module').then(m => m.NewsItemModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
