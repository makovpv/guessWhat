import { Component, OnInit } from '@angular/core';
import { QuestionService } from 'src/app/services/question.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  imageUrl: string = 'https://localhost:7022/api/question/image/11';
  options: any[];

  constructor(private questionService: QuestionService) { }

  ngOnInit(): void {
  }

  zoo(e) {
    this.questionService.getQuestion().then(x => {
      console.log(x);

      this.imageUrl = `https://localhost:7022/api/question/image/${x.imageId}`;

      this.options = x.options;
    });
  }

}
