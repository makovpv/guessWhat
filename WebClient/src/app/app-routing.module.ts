import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewPlaneComponent } from './components/new-plane/new-plane.component';
import { QuestionComponent } from './components/question/question.component';

const routes: Routes = [
  { path: 'new', component: NewPlaneComponent },
  { path: 'question', component: QuestionComponent },
  { 
    path: 'feature',
    loadChildren: () => import('./feature/my-feature/my-feature.module').then(m => m.MyFeatureModule)
  },
  { path: '', component: QuestionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
