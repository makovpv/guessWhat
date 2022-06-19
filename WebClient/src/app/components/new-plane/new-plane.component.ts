import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-new-plane',
  templateUrl: './new-plane.component.html',
  styleUrls: ['./new-plane.component.scss']
})
export class NewPlaneComponent implements OnInit {
  planeName: string;
  fileToUpload: any;

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
  }

  foo(e) {
    this.adminService.addNewPlane(this.planeName, this.fileToUpload)
      .then(x => alert('new plane added'));
  }

  boo(e) {
    this.fileToUpload = e.target.files[0];
    //this.fileName = this.fileToUpload.name;
  }

}
