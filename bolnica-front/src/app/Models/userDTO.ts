export class UserDTO {
  id: number;
  username: string;
  password: string;
  name: string;
  surname: string;
  eMail: string;
  phoneNumber: string;
  jmbg: string;
  address: string;
  gender: string;
  isAdmin: boolean = false;
  isBlocked: boolean = false;
}
