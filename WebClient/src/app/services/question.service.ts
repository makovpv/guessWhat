import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private httpClient: HttpClient) { }

  getQuestion(): any {
    return this.httpClient.get('https://localhost:7022/api/question').toPromise();
  }
}
