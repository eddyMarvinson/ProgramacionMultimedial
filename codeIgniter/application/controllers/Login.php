<?php  
defined('BASEPATH') OR exit('No direct script access allowed');  
  
class Login extends CI_Controller {  
      
    public function index()  
    {  
        $this->load->view('login_view');  
    }  
    public function process()  
    {  
        $user = $this->input->post('user');  
        $pass = $this->input->post('pass');
        $colorBack = 'white';
        if ($user=='1000' && $pass=='1234')   
        {  
            $this->session->set_userdata(array('user'=>$user, 'color'=>$colorBack));  
            $this->load->view('welcome_view');  
        }  
        else{  
            $data['error'] = 'Your Account is Invalid';  
            $this->load->view('login_view', $data);  
        }  
    }  
    public function logout()  
    {  
        $this->session->unset_userdata('user');  
        redirect("Login");  
    }  
    public function update(){
        $colorBack = $this->input->post('color');
        $this->session->set_userdata(array('color'=>$colorBack));
        $this->load->view('welcome_view');     
    }
}  
?>  