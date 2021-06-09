<?php
class FileCommon {
    private $file_name = "";
    function __construct($input_file_name) {
        $this->file_name = $input_file_name;
    }
    public function getFileData() {
        $value = file_get_contents($this->file_name);
        return $value;
    }
    public function inputFileData($data) {
        file_put_contents($this->file_name, $data);
    }
}


?>