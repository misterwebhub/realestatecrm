<html xmlns="http://www.w3.org/1999/xhtml"><head><title>Arazi Map 239</title>
</head><body>
<style>
    body {
        padding-top: 7%;
      padding-left: 0;
        margin: 0;
    }

    #form1 {
        width: 1420px;
        position: relative;
    }

    @media screen and (max-width: 1496px) {
        body {
            padding-top: 15% !important;
        padding-left: 0;
        }

        #form1 {
            transform: scale(0.8);
            transform-origin: top left;
        }
    }

    @media screen and (max-width: 1200px) {
        #form1 {
            transform: scale(0.65);
            transform-origin: top left;
        }

        body {
            padding-top: 20%;
        }
    }

    @media screen and (max-width: 992px) {
        #form1 {
            transform: scale(0.5);
            transform-origin: top left;
        }

        body {
            padding-top: 10%;
        }
    }
</style>

<?php
// Load shared DB credentials
require __DIR__ . '/../db-config.php';
$dbHost = MAP_DB_HOST;
$dbPort = MAP_DB_PORT;
$dbName = MAP_DB_NAME;
$dbUser = MAP_DB_USER;
$dbPass = MAP_DB_PASS;

$plots = [];
$serverDebug = [];
try {
  $dsn = "mysql:host={$dbHost};port={$dbPort};dbname={$dbName};charset=utf8mb4";
  $pdo = new PDO($dsn, $dbUser, $dbPass, [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);

  // treat file number as legacy arazi code and query plots by arazi_code
  $legacyCode = 239;
  $serverDebug['resolved_arazi_code'] = $legacyCode;

  // Fetch plots directly from the legacy arazi code stored on plots
  $stmt = $pdo->prepare('SELECT id, plot_number, area, status, title, description FROM plots WHERE arazi_code = ?');
  $stmt->execute([$legacyCode]);
  $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
  $serverDebug['query_used'] = 'plots_by_arazi_code';

  foreach ($rows as $r) {
    $dbStatus = strtolower(trim((string)($r['status'] ?? '')));

    // Default to available if status is empty
    if ($dbStatus === '') {
        $dbStatus = 'available';
    }

    $plots[] = [
        'id' => $r['id'],
        'plot_number' => $r['plot_number'],
        'status' => $dbStatus,
        'area' => $r['area'],
    ];
}
  $serverDebug['plots_count'] = count($plots);
} catch (Throwable $e) {
  $serverDebug['error'] = $e->getMessage();
}
?>
    

<form style="width: 1420px;position: relative;" method="post" action="./arazi319.aspx" id="form1">

 <img src="main.png" style="
    position: absolute;
    left: 8%;
    bottom: -83.2em;
">
 <img src="side.png" style="
    position: absolute;
    left: 132%;
    bottom: -96em;
">

 <img src="ver1.png" style="
    position: absolute;
    left: 60%;
    bottom: -80.2em;
    ">
	  
   




    
    
    
    
     
     
   
 <img src="left1.png" style="
    position: absolute;
    left: 35em;
    top:-3em;
    ">
    <div style="
    width: 134px;
    height: 3.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 50.3%;
    border: 1px solid;
    "><span>119</span></div>

    <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
   left: 47.6%;
   border: 1px solid;
   "><span>118</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
   left: 44.9%;
   border: 1px solid;
   "><span>117</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
  left: 42.2%;
   border: 1px solid;
   "><span>116</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
    left: 39.5%;
   border: 1px solid;
   "><span>115</span></div>

   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
   left: 47.6%;
   border: 1px solid;
   top:7.5em;
   "><span>124</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
   left: 44.9%;
   border: 1px solid;
   top:7.5em;
   "><span>125</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
  left: 42.2%;
   border: 1px solid;
   top:7.5em;
   "><span>126</span></div>
   <div style="
   width: 35px;
   height: 7.3em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
    left: 39.5%;
   border: 1px solid;
   top:7.5em;
   "><span>127</span></div>
<div style="position:relative;right:59.5em;top:6.9em;">

    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>128</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>129</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>130</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>131</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>132</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>133</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>134</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>135</span></div>
    <div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>136</span></div>
<div style="
   width: 30px;
    height: 3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>137</span></div>
</div>
     <div style="
    width: 134px;
    height: 2.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -6.1em;
    left: 50.3%;
    border: 1px solid;
    "><span>120</span></div>

     <div style="
    width: 134px;
    height: 2.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -8.7em;
    left: 50.3%;
    border: 1px solid;
    "><span>121</span></div>
       
     <div style="
    width: 134px;
    height: 2.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -11.3em;
    left: 50.3%;
    border: 1px solid;
    "><span>122</span></div>
    
     
       <div style="
    width: 134px;
    height: 3.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
     bottom: -14.9em; 
    left: 50.3%;
    border: 1px solid;
    "><span>123</span></div>
     
        
     
     
     
     
     
  
 

 

     <img src="ver2.png" style="
    position: absolute;
    left: 60%;
    top: -3em;
">
 
     <div style="
   width: 40px;
   height: 3.9em;
   background: yellow;
   position: absolute;
   /* padding: 20px; */
   text-align: center;
   vertical-align: middle;
   top: 78.5px;
   left: 120.7%;
   border: 1px solid;
   "><span>90</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>89</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>88</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>87</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>86</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>85</span></div>

    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>84</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>83</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>82</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>81</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>80</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>79</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>78</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>77</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>76</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>75</span></div>
<div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>74</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 80.4%;
    border: 1px solid;
    "><span>73</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 78%;
    border: 1px solid;
    "><span>72</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 75.6%;
    border: 1px solid;
    "><span>71</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 73.3%;
    border: 1px solid;
    "><span>70</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 70.9%;
    border: 1px solid;
    "><span>69</span></div>
    <div style="
    width: 90px;
    height: 3.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 4.8em;
    "><span>68</span></div>
    <div style="
    width: 90px;
    height: 2.7em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 8.5em;
    "><span>67</span></div>
   <div style="
    width: 90px;
    height: 3.55em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 11.3em;
    "><span>66</span></div>
    
    <img src="right1.png" style="
    position: absolute;
    left: 57em;
    top:2em;
    ">

    <div style="
   width: 20px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 123%;
    border: 1px solid;
    "><span>91</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 120.7%;
    border: 1px solid;
    "><span>92</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>93</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>94</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>95</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>96</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>97</span></div>

    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>98</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>99</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>100</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>101</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 97%;
    border: 1px solid;
    "><span>102</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>103</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>104</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>105</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>106</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>107</span></div>
<div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>108</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 80.4%;
    border: 1px solid;
    "><span>109</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 78%;
    border: 1px solid;
    "><span>110</span></div>
    <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 75.6%;
    border: 1px solid;
    "><span>111</span></div>
     <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 73.3%;
    border: 1px solid;
    "><span>112</span></div>
 <div style="
   width: 30px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: -32.5px;
    left: 70.9%;
    border: 1px solid;
    "><span>113</span></div>
    
    <div style="
    width: 90px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: -2em;
    "><span>114</span></div>
 <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 70.8%;
    border: 1px solid;
    top: 9em;
    "><span>65</span></div>
     <div style="
    width: 35px;
    height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 121.1%;
    border: 1px solid;
    top: 9em;
    "><span>50</span></div>
     <div style="
    width: 45px;
    height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 117.7%;
    border: 1px solid;
    top: 9em;
    "><span>51</span></div>
    <div style="
    width: 45px;
    height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 114.35%;
    border: 1px solid;
    top: 9em;
    "><span>52</span></div>
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 111%;
    border: 1px solid;
    top: 9em;
    "><span>53</span></div>

       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 107.65%;
    border: 1px solid;
    top: 9em;
    "><span>54</span></div>
       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 104.30%;
    border: 1px solid;
    top: 9em;
    "><span>55</span></div>
       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 100.95%;
    border: 1px solid;
    top: 9em;
    "><span>56</span></div>
      <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 97.60%;
    border: 1px solid;
    top: 9em;
    "><span>57</span></div>
      <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 94.25%;
    border: 1px solid;
    top: 9em;
    "><span>58</span></div>
        <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 90.90%;
    border: 1px solid;
    top: 9em;
    "><span>59</span></div>
    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 87.55%;
    border: 1px solid;
    top: 9em;
    "><span>60</span></div>
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 84.20%;
    border: 1px solid;
    top: 9em;
    "><span>61</span></div>
    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 80.85%;
    border: 1px solid;
    top: 9em;
    "><span>62</span></div>
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 77.50%;
    border: 1px solid;
    top: 9em;
    "><span>63</span></div>

    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 74.15%;
    border: 1px solid;
    top: 9em;
    "><span>64</span></div>

     
     
     
     
     
     
     
        
     
     
     
     
     


<div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 70.8%;
    border: 1px solid;
    "><span>32</span></div>
<div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 73.4%;
    border: 1px solid;
    "><span>31</span></div>
   <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 76%;
    border: 1px solid;
    "><span>30</span></div>
   <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 78.6%;
    border: 1px solid;
    "><span>29</span></div>
   <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 81.2%;
    border: 1px solid;
    "><span>28</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 83.8%;
    border: 1px solid;
    "><span>27</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 86.4%;
    border: 1px solid;
    "><span>26</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 89%;
    border: 1px solid;
    "><span>25</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 91.6%;
    border: 1px solid;
    "><span>24</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 94.2%;
    border: 1px solid;
    "><span>23</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 96.8%;
    border: 1px solid;
    "><span>22</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 99.4%;
    border: 1px solid;
    "><span>21</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 102%;
    border: 1px solid;
    "><span>20</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 104.6%;
    border: 1px solid;
    "><span>19</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 107.2%;
    border: 1px solid;
    "><span>18</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 109.8%;
    border: 1px solid;
    "><span>17</span></div>
     <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 112.4%;
    border: 1px solid;
    "><span>16</span></div>
     <div style="
width: 20px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 115%;
    border: 1px solid;
    "><span>15</span></div>
    <div style="
width: 35px;
    height: 4.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    bottom: -29.5em;
    left: 78.6%;
    border: 1px solid;
    "><span>29</span></div>
  

 <img src="right2.png" style="
    position: absolute;
    left: 57em;
    top:15em;
    ">

    
     <img src="left2.png" style="
    position: absolute;
    left: 13em;
    top:15em;
    ">

    
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 114.35%;
    border: 1px solid;
    top: 18.8em;
    "><span>49</span></div>
      
         <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 111%;
    border: 1px solid;
    top: 18.8em;
    "><span>48</span></div>

       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 107.65%;
    border: 1px solid;
    top: 18.8em;
    "><span>47</span></div>
       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 104.30%;
    border: 1px solid;
    top: 18.8em;
    "><span>46</span></div>
       <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 100.95%;
    border: 1px solid;
    top: 18.8em;
    "><span>45</span></div>
      <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 97.60%;
    border: 1px solid;
    top: 18.8em;
    "><span>44</span></div>
      <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 94.25%;
    border: 1px solid;
    top: 18.8em;
    "><span>43</span></div>
        <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 90.90%;
    border: 1px solid;
    top: 18.8em;
    "><span>42</span></div>
    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 87.55%;
    border: 1px solid;
    top: 18.8em;
    "><span>41</span></div>
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 84.20%;
    border: 1px solid;
    top: 18.8em;
    "><span>40</span></div>
    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 80.85%;
    border: 1px solid;
    top: 18.8em;
    "><span>39</span></div>
     <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 77.50%;
    border: 1px solid;
    top: 18.8em;
    "><span>38</span></div>

    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 74.15%;
    border: 1px solid;
    top: 18.8em;
    "><span>37</span></div>
    <div style="
    width: 45px;
     height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 70.8%;
    border: 1px solid;
    top: 18.8em;
    "><span>36</span></div>
    
     <div style="
    width: 90px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 18.8em;
    "><span>35</span></div>
    <div style="
    width: 90px;
    height: 2.7em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 22.7em;
    "><span>34</span></div>
   <div style="
    width: 90px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 25.6em;
    "><span>33</span></div>
    
       <div style="
    width: 45px;
    height: 6.3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 108.3%;
    border: 1px solid;
    "><span>14</span></div>
         <div style="
    width: 45px;
    height: 6.2em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 105%;
    border: 1px solid;
    "><span>13</span></div>
     <div style="
    width: 45px;
    height: 6.1em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 101.7%;
    border: 1px solid;
    "><span>12</span></div>
     <div style="
    width: 45px;
    height: 6em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 98.4%;
    border: 1px solid;
    "><span>11</span></div>
     <div style="
    width: 45px;
    height: 5.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 95.1%;
    border: 1px solid;
    "><span>10</span></div>
      <div style="
    width: 45px;
    height: 5.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 91.8%;
    border: 1px solid;
    "><span>9</span></div>
        <div style="
    width: 45px;
    height: 5.7em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 88.5%;
    border: 1px solid;
    "><span>8</span></div>
      <div style="
    width: 45px;
    height: 5.6em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 85.2%;
    border: 1px solid;
    "><span>7</span></div>
    <div style="
    width: 45px;
    height: 5.5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 81.9%;
    border: 1px solid;
    "><span>6</span></div>
     <div style="
    width: 45px;
    height: 5.4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 78.6%;
    border: 1px solid;
    "><span>5</span></div>
     <div style="
    width: 45px;
    height: 5.3em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 75.3%;
    border: 1px solid;
    "><span>4</span></div>
     <div style="
    width: 45px;
    height: 5.2em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 72%;
    border: 1px solid;
    "><span>3</span></div>
     <div style="
    width: 45px;
    height: 5.1em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 68.7%;
    border: 1px solid;
    "><span>2</span></div>
     <div style="
    width: 60px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 32.3em;
    left: 64.3%;
    border: 1px solid;
    "><span>1</span></div>
     
      <img src="right3.png" style="
    position: absolute;
    left: 57em;
    top:29.5em;
    ">

     
<img src="left2.png" style="
    position: absolute;
    left: 13em;
    top:29em;
    ">     
    <div style="position: relative;top: -0.7em;left: -9.9%;">

<div style="
    width: 75px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 18.8em;
    "><span>154</span></div>
    <div style="
    width: 75px;
    height: 2.7em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 22.7em;
    "><span>155</span></div>

<div style="position:relative;top: 13.9em;left: -56.3%;">
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>153</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>152</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>151</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>150</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>149</span></div>

    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>148</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>147</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>146</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>145</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>144</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>143</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>142</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>141</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>140</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>139</span></div>
<div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>138</span></div>

    </div>

   <div style="
    width: 75px;
    height: 3.8em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    /* bottom: -5.9em; */
    left: 64.3%;
    border: 1px solid;
    top: 25.6em;
    "><span>156</span></div>
    </div>
<div style="position:relative;top: 18.8em;left: -66.3%;">
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>157</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>158</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>159</span></div>
     <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>160</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>161</span></div>

    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>162</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>163</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>164</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>165</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>166</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>167</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>168</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>169</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>170</span></div>
    <div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>171</span></div>
<div style="
   width: 30px;
    height: 5em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>172</span></div>

    </div>
     
    <img src="left3.png" style="
    position: absolute;
    left: 12.6em;
    top:40em;
    ">     

    <img src="area.png" style="
    position: absolute;
    left: 12.5em;
    top:42.8em;
    ">
    
      <div style="
   width: 158px;
    height: 10.6em;
    background: none rgb(40, 167, 69);
    position: absolute;
    text-align: center;
    vertical-align: middle;
    top: 42.9em;
    left: 48.7%;
    border: 1px solid;
    color: rgb(255, 255, 255);
    "><span>209</span></div>

     <div style="
    width: 75px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 31.9em;
    left: 54.5%;
    border: 1px solid;
    "><span>190</span></div>

<div style="position: relative;top: 27em;left: -66.2%;">
   
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>189</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>188</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>187</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>186</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>185</span></div>

    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>184</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>183</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>182</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>181</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>180</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>179</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>178</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>177</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>176</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>175</span></div>
<div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>174</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 80.4%;
    border: 1px solid;
    "><span>173</span></div>
     
   
    </div>

     <div style="
    width: 75px;
    height: 4em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 36em;
    left: 54.5%;
    border: 1px solid;
    "><span>191</span></div>
   
   <div style="position: relative;top: 31.2em;left: -66.2%;">
   
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 118.3%;
    border: 1px solid;
    "><span>192</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 115.9%;
    border: 1px solid;
    "><span>193</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 113.6%;
    border: 1px solid;
    "><span>194</span></div>
     <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 111.2%;
    border: 1px solid;
    "><span>195</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 108.8%;
    border: 1px solid;
    "><span>196</span></div>

    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 106.5%;
    border: 1px solid;
    "><span>197</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 104.1%;
    border: 1px solid;
    "><span>198</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 101.7%;
    border: 1px solid;
    "><span>199</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 99.4%;
    border: 1px solid;
    "><span>200</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 97%;
    border: 1px solid;
    "><span>201</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 94.6%;
    border: 1px solid;
    "><span>202</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 92.3%;
    border: 1px solid;
    "><span>203</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 89.9%;
    border: 1px solid;
    "><span>204</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 87.5%;
    border: 1px solid;
    "><span>205</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 85.1%;
    border: 1px solid;
    "><span>206</span></div>
<div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 82.7%;
    border: 1px solid;
    "><span>207</span></div>
    <div style="
   width: 30px;
    height: 3.9em;
    background: yellow;
    position: absolute;
    /* padding: 20px; */
    text-align: center;
    vertical-align: middle;
    top: 78.5px;
    left: 80.4%;
    border: 1px solid;
    "><span>208</span></div>
     
   
    </div>
	</form>


<style>
:root {
  --status-available: #FFC107;
  --status-booked: #28A745;
  --status-booked-advance: #20C997;
  --status-not-for-sale: #9E9E9E;
  --status-blacklist: #212529;
  --status-hold: #A0522D;
  --status-registry: #E53935;
  --status-issue: #6C757D;
}
#plots-popup { position: fixed; inset: 6% 6% auto 6%; background: #fff; border:1px solid #ccc; box-shadow: 0 6px 24px rgba(0,0,0,0.2); z-index:9999; display:none; max-height:88%; overflow:auto; border-radius:8px; }
#plots-popup .pp-header { padding:10px 12px; border-bottom:1px solid #eee; display:flex; justify-content:space-between; align-items:center; }
#plots-popup .pp-body { padding:12px; }
#pp-legend { display:flex; gap:8px; flex-wrap:wrap; margin-bottom:12px; }
.pp-legend-item { display:inline-flex; align-items:center; gap:8px; padding:6px 10px; border-radius:8px; cursor:pointer; background:transparent; }
.pp-legend-item.active { background:rgba(0,0,0,0.04); transform:translateY(-2px); }
.legend-dot { width:12px; height:12px; border-radius:50%; display:inline-block; margin-right:6px; }
.legend-dot.available { background:var(--status-available); }
.legend-dot.booked { background:var(--status-booked); }
.legend-dot.booked-advance { background:var(--status-booked-advance); }
.legend-dot.registry { background:var(--status-registry); }
.legend-dot.not-for-sale { background:var(--status-not-for-sale); }
.legend-dot.blacklist { background:var(--status-blacklist); }
.legend-dot.hold { background:var(--status-hold); }
.legend-dot.issue { background:var(--status-issue); }
.pp-grid { display:flex; gap:10px; flex-wrap:wrap; }
.plot-card { background:linear-gradient(180deg,#ffffff, #fcfcfc); border-radius:8px; overflow:hidden; box-shadow:0 6px 18px rgba(0,0,0,0.06); transition:transform .12s ease; cursor:pointer; width:160px; }
.plot-card:hover { transform:translateY(-6px); }
.plot-strip { height:9px; }
.plot-strip.available { background:var(--status-available); }
.plot-strip.booked { background:var(--status-booked); }
.plot-strip.booked-advance { background:var(--status-booked-advance); }
.plot-strip.registry { background:var(--status-registry); }
.plot-strip.not-for-sale { background:var(--status-not-for-sale); }
.plot-strip.blacklist { background:var(--status-blacklist); }
.plot-strip.hold { background:var(--status-hold); }
.plot-strip.issue { background:var(--status-issue); }
.plot-card-body { padding:8px; text-align:center; }
.plot-number { font-weight:700; font-size:18px; }
.plot-area { color:#5c6975; font-size:13px; }
.plot-status { display:inline-block; padding:4px 8px; border-radius:10px; font-size:13px; margin-top:6px; }
#pp-close { border:none;background:transparent;cursor:pointer;font-size:18px; }
</style>
<div id="plots-popup">
    <div class="pp-header">
        <strong>Plots</strong>
        <div><button id="pp-close" type="button">✕</button></div>
    </div>
    <div class="pp-body">
        <div id="pp-legend"></div>
        <div id="pp-content" class="pp-grid"></div>
        <div id="pp-detail" style="display:none;margin-top:12px;border-top:1px solid #eee;padding-top:12px;"></div>
    </div>
</div>
<script>
window.plots = <?php echo json_encode($plots, JSON_UNESCAPED_SLASHES|JSON_UNESCAPED_UNICODE); ?> || [];
document.addEventListener('DOMContentLoaded', function(){
  const serverDebug = <?php echo json_encode($serverDebug, JSON_UNESCAPED_SLASHES|JSON_UNESCAPED_UNICODE); ?> || {};
  console.log('serverDebug', serverDebug);
  const colorMap = {
    'available':'#FFC107',
    'booked':'#28A745',
    'booked-advance':'#28A745',
    'booked_advance':'#28A745',
    'not_for_sale':'#9E9E9E',
    'not-for-sale':'#9E9E9E',
    'blacklist':'#212529',
    'hold':'#A0522D',
    'registry':'#E53935',
    'issue':'#FFC107'
  };

  const plots = window.plots || [];
  const plotStatusByNumber = {};
  plots.forEach(p => {
    const rawValue = String(p.plot_number || p.title || p.id || '').trim();
    const numMatch = rawValue.match(/\d+/);
    const rawStatus = String(p.status || 'available').toLowerCase().replace(/adwance/g,'advance');
    const statusKey = rawStatus.replace(/[_\s]+/g,'-');
    if (numMatch) plotStatusByNumber[numMatch[0]] = statusKey || 'available';
  });

  let detectedOffset = null;
  const numericKeys = Object.keys(plotStatusByNumber).map(k => parseInt(k, 10)).filter(n => !isNaN(n)).sort((a,b) => a - b);
  if (numericKeys.length) {
    const minK = numericKeys[0];
    const maxK = numericKeys[numericKeys.length - 1];
    if ((maxK - minK + 1) === numericKeys.length && minK > 1) {
      detectedOffset = minK - 1;
      console.log('detected plot_number offset:', detectedOffset);
    }
  }

  function mapTileNumberToPlotNumber(tileNumStr) {
    if (!tileNumStr) return tileNumStr;
    if (plotStatusByNumber[tileNumStr]) return tileNumStr;
    if (detectedOffset !== null) {
      const candidate = String((parseInt(tileNumStr, 10) || 0) + detectedOffset);
      if (plotStatusByNumber[candidate]) return candidate;
    }
    return tileNumStr;
  }

  const spans = Array.from(document.querySelectorAll('form span'));
  spans.forEach(sp => {
    const txt = (sp.textContent || '').trim();
    const m = txt.match(/^\d+$/);
    if (!m) return;
    const tileNum = m[0];
    const mapped = mapTileNumberToPlotNumber(tileNum);
    const status = (mapped && plotStatusByNumber[mapped]) ? plotStatusByNumber[mapped] : 'available';
    const parent = sp.closest('div');
    if (!parent) return;
    parent.style.backgroundImage = 'none';
    const clr = colorMap[status] || colorMap['available'];
    parent.style.backgroundColor = clr;
    parent.style.color = (['#212529', '#28A745', '#E53935', '#A0522D'].includes(clr)) ? '#fff' : '#000';
  });

  const pp = document.getElementById('plots-popup');
  const ppLegend = document.getElementById('pp-legend');
  const ppContent = document.getElementById('pp-content');
  const btn = document.getElementById('show_plots_btn');

  const statusLabels = [
    {key:'all', label:'All'},
    {key:'available', label:'Available'},
    {key:'booked', label:'Booked'},
    {key:'booked-advance', label:'Booked (advance)'},
    {key:'hold', label:'Hold'},
    {key:'registry', label:'Registry'},
    {key:'not-for-sale', label:'Not for sale'},
    {key:'blacklist', label:'Blacklist'},
    {key:'issue', label:'Issue'}
  ];

  function normalizeStatus(s){ return String(s || 'available').toLowerCase().replace(/[_ ]+/g,'-'); }

  function buildLegend(){
    ppLegend.innerHTML = '';
    const counts = {};
    (plots || []).forEach(p => { const k = normalizeStatus(p.status); counts[k] = (counts[k] || 0) + 1; });
    const total = (plots || []).length;
    statusLabels.forEach(function(s, idx){
      const el = document.createElement('div');
      el.className = 'pp-legend-item' + (idx === 0 ? ' active' : '');
      el.dataset.key = s.key;
      const dot = document.createElement('span'); dot.className = 'legend-dot ' + (s.key === 'all' ? 'available' : s.key.replace(/_/g,'-'));
      el.appendChild(dot);
      const txt = document.createElement('span');
      const cnt = (s.key === 'all') ? total : (counts[s.key] || 0);
      txt.innerHTML = s.label + ' <small style="color:#666;margin-left:6px">(' + cnt + ')</small>';
      el.appendChild(txt);
      el.addEventListener('click', function(){
        Array.from(ppLegend.children).forEach(c => c.classList.remove('active'));
        el.classList.add('active');
        renderPlots(s.key);
      });
      ppLegend.appendChild(el);
    });
  }

  function renderPlots(filterKey){
    ppContent.innerHTML = '';
    const ppDetail = document.getElementById('pp-detail'); ppDetail.style.display = 'none'; ppDetail.innerHTML = '';
    const items = (filterKey === 'all') ? (plots || []) : (plots || []).filter(p => normalizeStatus(p.status) === filterKey);
    if (!items.length) { ppContent.innerHTML = '<div style="padding:8px;color:#666">No plots in this category.</div>'; return; }
    items.forEach(function(p){
      const card = document.createElement('div'); card.className = 'plot-card';
      const strip = document.createElement('div'); strip.className = 'plot-strip ' + normalizeStatus(p.status);
      const body = document.createElement('div'); body.className = 'plot-card-body';
      body.innerHTML = '<div class="plot-number">' + (p.plot_number || p.title || p.id) + '</div>' +
        '<div class="plot-area">' + (p.area || '-') + ' gaz</div>' +
        '<div class="plot-status">' + (p.status || '') + '</div>';
      card.appendChild(strip); card.appendChild(body);
      card.addEventListener('click', function(){ renderPlotDetail(p); });
      ppContent.appendChild(card);
    });
  }

  function renderPlotDetail(p){
    const ppDetail = document.getElementById('pp-detail');
    ppDetail.style.display = '';
    ppDetail.innerHTML = '';
    const back = document.createElement('button'); back.textContent = '← Back to list'; back.type = 'button'; back.style.marginBottom = '8px';
    back.addEventListener('click', function(){ ppDetail.style.display = 'none'; });
    const title = document.createElement('h5'); title.textContent = 'Plot ' + (p.plot_number || p.title || p.id);
    const info = document.createElement('div'); info.style.marginTop = '8px';
    info.innerHTML = '<div><strong>Area:</strong> ' + (p.area || '-') + ' gaz</div>' +
      '<div><strong>Status:</strong> ' + (p.status || '-') + '</div>' +
      '<div><strong>ID:</strong> ' + (p.id) + '</div>';
    ppDetail.appendChild(back); ppDetail.appendChild(title); ppDetail.appendChild(info);
    ppDetail.scrollIntoView({behavior:'smooth', block:'center'});
  }

  btn.addEventListener('click', function(){
    buildLegend();
    renderPlots('all');
    pp.style.display = 'block';
  });
  document.getElementById('pp-close').addEventListener('click', function(){ pp.style.display = 'none'; });
  document.addEventListener('keydown', function(e){ if (e.key === 'Escape') pp.style.display = 'none'; });
});
</script>
</body></html>