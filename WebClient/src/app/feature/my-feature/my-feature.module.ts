import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeatureViewComponent } from '../feature-view/feature-view.component';



@NgModule({
  declarations: [
    FeatureViewComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    FeatureViewComponent
  ]
})
export class MyFeatureModule { }
