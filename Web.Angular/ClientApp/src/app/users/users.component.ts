import { Component, OnInit } from '@angular/core';
import { Observable, combineLatest, forkJoin } from 'rxjs';
import { UsersService } from './users.service';
import { IUser, User } from '../shared/models/user.model';
import { ToastService } from '../shared/services/toast-service.service';
import { DepartmentsService } from '../shared/services/departments.service';
import { IDepartment } from '../shared/models/department.model';

@Component({
  selector: 'app-users',
  styleUrls: [],
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {
  loading: boolean;
  users: User[];

  constructor(private service: UsersService,
    private departmentService: DepartmentsService,
    public toastService: ToastService) {
   
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(): void {
    this.loading = true;
    let departments = this.departmentService.getDepartments();
    let users = this.service.getUsers();
    forkJoin([users, departments])
      .subscribe(([u, d]) => {
        this.setUsers(u.users, d.departments);
        this.loading = false;
    });
  }

  private setUsers(users: IUser[], departments: IDepartment[]) {
    this.users = users.map((u) => {
      let user = new User();
      user.id = u.id;
      user.userName = u.userName;
      user.departmentId = u.departmentId;

      let department = departments.find((element) => element.id == u.departmentId);
      if (department) {
        user.departmentTitle = department.title;
      }

      return user;
    });
  }

  dropUser(user: IUser) {
    this.service.dropUser(user.id).subscribe(response => {
      this.getUsers();
      this.toastService.show('User deleted!', { classname: 'bg-danger text-light', delay: 1500 });
    })
  }

  private handleError(error: any) {
    this.toastService.show('Get users failed', { classname: 'bg-warning text-light'});
    return Observable.throw(error);
  } 
}
