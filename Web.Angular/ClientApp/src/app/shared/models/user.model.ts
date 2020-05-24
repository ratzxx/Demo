

export interface IUser {
  id: number;
  userName: string;
  departmentId: number;
}

export class User implements IUser {
  id: number;
  userName: string;
  departmentId: number;
  departmentTitle: string;
}
