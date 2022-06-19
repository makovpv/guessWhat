import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeatureViewComponent } from '../feature-view/feature-view.component';
import { MyFeatureRoutingModule } from './my-feature-routing.module';


@NgModule({
  declarations: [
    FeatureViewComponent
  ],
  imports: [
    CommonModule,
    MyFeatureRoutingModule
  ]
})
export class MyFeatureModule { }
