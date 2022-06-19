import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewPlaneComponent } from './components/new-plane/new-plane.component';
import { QuestionComponent } from './components/question/question.component';
import { MyFeatureModule } from './feature/my-feature/my-feature.module';

@NgModule({
  declarations: [
    AppComponent,
    NewPlaneComponent,
    QuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MyFeatureModule
  ],
  providers: [
    // {
    //   provide: UrlSerializer,
    //   useClass: LowerCaseUrlSerializer
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
