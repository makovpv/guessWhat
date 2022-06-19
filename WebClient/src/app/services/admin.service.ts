import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) { }

  addNewPlane(name: string, image: any): Promise<any> {
    const formData = new FormData();
    formData.append('name', name);
    formData.append('file', image);

    return this.httpClient.post('https://localhost:7022/api/admin/plane', formData).toPromise();
  }
}
