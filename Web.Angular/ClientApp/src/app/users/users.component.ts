import { Component, OnInit } from '@angular/core';
// import { ConfigurationService } from '../shared/services/configuration.service';
import { Observable, combineLatest, forkJoin } from 'rxjs';
import { catchError, first } from 'rxjs/operators';
import { UsersService } from './users.service';
import { IUser, User } from '../shared/models/user.model';

import { ToastService } from '../shared/services/toast-service.service';
import { NgbModal, NgbModalRef, NgbToast } from "@ng-bootstrap/ng-bootstrap";
import { UsersDetailComponent } from './users-detail/users-detail.component';
import { DepartmentsService } from '../shared/services/departments.service';
import { IDepartment } from '../shared/models/department.model';
import { IDepartments } from '../shared/models/departments.model';
import { IUsers } from '../shared/models/users.model';

@Component({
  selector: 'app-users',
  styleUrls: [],
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {

  users: User[];
  protected modalRef: NgbModalRef;

  constructor(private service: UsersService,
    private departmentService: DepartmentsService,
    public toastService: ToastService,
    protected modalService: NgbModal) {
   
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers(): void {
    let departments = this.departmentService.getDepartments();
    let users = this.service.getUsers();
    forkJoin([users, departments])
      .subscribe(([u, d]) => {
        this.setUsers(u.users, d.departments);
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

  editUser(user: IUser) {
    this.modalRef = this.modalService.open(UsersDetailComponent);
    this.modalRef.componentInstance.title = 'Edit user';
    this.modalRef.componentInstance.user = user;
  }

  private handleError(error: any) {
    this.toastService.show('Get users failed', { classname: 'bg-warning text-light'});
    return Observable.throw(error);
  } 
}
