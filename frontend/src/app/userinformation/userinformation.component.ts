import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-userinformation',
  templateUrl: './userinformation.component.html',
  styleUrls: ['./userinformation.component.css']
})
export class UserinformationComponent implements OnInit {

  form!: FormGroup;
  editMode = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit(): void {
  this.form = this.fb.group({
    name: [''],
    lastName: [''],
    phone: [''],
    location: [''],
    birthDate: [''],
    email: [{ value: '', disabled: true }]
  });

  this.form.disable();

  this.loadData();
}

 loadData() {
  this.userService.getMe().subscribe(user => {

    if (user.birthDate) {
      user.birthDate = user.birthDate.split('T')[0];
    }

    this.form.patchValue(user);
  });
  }


  editar() {
    this.editMode = true;
    this.form.enable();
    this.form.get('email')?.disable();
  }

  salvar() {
  const data = this.form.getRawValue();
  console.log("ENVIANDO:", data);

  this.userService.updateMe(data).subscribe({
    next: () => {
      this.editMode = false;
      this.form.disable();
    },
    error: (err) => {
      console.log("ERRO BACKEND:", err.error);
      console.log("VALIDATION:", err.error?.errors);
    }
  });
}
}

