<?php
date_default_timezone_set('Asia/Taipei');
session_start();

$time=date('Y-m-d H:i:s');

function conn()
{
	$a = mysqli_connect('localhost','root','','photo');
	if($a->connect_error)
	{
		die($a->connect_error);
		exit;
	}
	mysqli_set_charset($a, 'utf8');
	return $a;
}

function squery($a)
{
	$b = conn();
	$c = $b->query($a[1]);
	switch($a[0])
	{
		case 'get':
			$d = mysqli_fetch_array($c);
			$b->close();
			return $d;
		break;
		case 'list':
			$e=1;
			$f=[];
			while($d = mysqli_fetch_array($c))
			{
				$f[$e]=$d;
				$e++;
			}
			$b->close();
			return $f;
		break;
		case 'run':
			if($c)
			{
				return true;
			}
			else
			{
				echo $b->error;
				return false;
			}
		break;
		default:
			echo 'noselect';
		break;
	}
}
function txt($a){echo "<h1>$a</h1>";}
function txts($a){return "<h1>$a</h1>";}
function ref($a)
{
	header('refresh:'.$a[0].';url="'.$a[1].'"');
}

function res($a,$b)
{
	if($a){
		txt($b[0]);
		ref([$b[2],$b[3]]);
	}else{
		txt($b[1]);
		ref([$b[2],$b[3]]);
	}
}
// arr => str
function obj_e($a)
{
	$str = "";
	for($i=1;$i<=count($a);$i++)
	{
		$str .= "/";
		for($y=0;$y<=count($a[$i])-1;$y++)
		{
			if($y===count($a[$i])-1)
			{
				$str .= $a[$i][$y];
			}
			else
			{
				$str .= $a[$i][$y].":";
			}
		}
	}
	return $str;
}

// str => arr
function obj_d($a)
{
	$obj=[];
	$b = explode('/',$a);
	for($i=1;$i<=count($b)-1;$i++)
	{
		$c = l($b[$i]); // [0]=>1,[1]=>2,
		for($y=0;$y<=count($c)-1;$y++)
		{
			$obj[$i][$y] = $c[$y];
		}
	}
	return $obj;
}

function p($a){return $_POST[$a];}
function f($a){return $_FILES[$a];}
function v($a){var_dump($a);}
function k($a){return md5($a);}





