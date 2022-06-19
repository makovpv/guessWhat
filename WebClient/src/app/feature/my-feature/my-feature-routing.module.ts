import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FeatureViewComponent } from "../feature-view/feature-view.component";

const routes: Routes = [
    {
        path: '',
        component: FeatureViewComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class MyFeatureRoutingModule { }