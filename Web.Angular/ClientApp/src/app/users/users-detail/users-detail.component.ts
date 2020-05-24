import { Component, Input, OnInit  } from '@angular/core';
import { IUser, User } from '../../shared/models/user.model';
import { DepartmentsService } from '../../shared/services/departments.service';
import { IDepartment } from '../../shared/models/department.model';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../users.service';
import { first, catchError } from 'rxjs/operators';
import { ToastService } from '../../shared/services/toast-service.service';
import { Observable } from 'rxjs';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-users-detail',
  templateUrl: './users-detail.component.html'
})
export class UsersDetailComponent implements OnInit  {
  user: IUser;

  departments: IDepartment[];

  isNewUser: boolean;
  userForm: FormGroup;

  constructor(private userService: UsersService,
    private departmentService: DepartmentsService,
    public toastService: ToastService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit() {
    this.getDepartments();
    let userId = parseInt(this.route.snapshot.paramMap.get('id'));
    if (userId) {
      this.getUser(userId);
    }
    else {
      this.isNewUser = true;
      this.user = new User();
      this.createForm();
    }
    
  }

  createForm() {
    this.userForm = new FormGroup({
      'username': new FormControl(this.user.userName, [
        Validators.required
      ]),
      'departmentId': new FormControl(this.user.departmentId, Validators.required)
    });
  }

  get username() {
    return this.userForm.get('username');
  }

  get departmentId() {
    return this.userForm.get('departmentId');
  }

  getUser(userId: number) {
    this.userService.getUser(userId)
      .pipe(first())
      .subscribe(response => {
        if (!response) {
          this.router.navigate(['404']);
        }
        this.user = response;
        this.createForm();
      });
  }

  getDepartments() {
    this.departmentService.getDepartments()
      .pipe(first())
      .subscribe(response => {
        this.departments = response.departments;
      });
  }

  updateUser() {
    this.user.userName = this.userForm.value.username;
    this.user.departmentId = this.userForm.value.departmentId;

    this.userService.updateUser(this.user)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(() => {
        this.toastService.show("User updated!", { classname: 'bg-success text-light' });
    })
  }

  createUser() {
    this.userService.createUser(this.userForm.value)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(() => {
        this.toastService.show("User created!", { classname: 'bg-success text-light' });
        this.router.navigate(['/']);
    });
  }

  private handleError(error: any) {
    this.toastService.show('Failed!', { classname: 'bg-warning text-light' });
    return Observable.throw(error);
  } 

}
