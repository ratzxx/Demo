import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IDepartments } from '../models/departments.model';

@Injectable()
export class DepartmentsService {
  private departmentsUrl: string = '';

  constructor(private http: HttpClient) {
    this.departmentsUrl = 'https://departmentapi20200524092143.azurewebsites.net/departments';
  }

  getDepartments(): Observable<IDepartments> {
    return this.http.get<IDepartments>(this.departmentsUrl);
  }
}
