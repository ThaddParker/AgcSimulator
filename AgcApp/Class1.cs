﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AgcApp
{
    internal class Benchmark
    {
        private string Benchmark_File =
            "// This work is licensed under the POV-Ray v3.8 distribution license.\n" +
            "// To view a copy of this license, visit http://www.povray.org/licences/v3.8/.\n" +
            "//\n" +
            "// The following exception is granted to the above license terms:\n" +
            "// Permission is granted for this file and the output from it to be\n" +
            "// freely redistributed in an unmodified form for the purpose of\n" +
            "// generating and maintaining POV-Ray benchmarks.  Derivative works\n" +
            "// are permitted provided that they have a clearly different filename\n" +
            "// and do not claim to be the standard benchmark file.\n" +
            "//\n" +
            "// ==================================================================\n" +
            "//\n" +
            "// Persistence Of Vision Ray Tracer Scene Description File\n" +
            "//\n" +
            "// File:            benchmark.pov\n" +
            "// Benchmark Vers:  2.03 Scene File Version\n" +
            "// Desc:            POV-Ray benchmark scene\n" +
            "// Date:            October/November 2001 (initial release)\n" +
            "//\n" +
            "// Assembled by Christoph Hormann\n" +
            "// Contributions by:\n" +
            "//    - Ingo Janssen\n" +
            "//    - Mick Hazelgrove\n" +
            "//\n" +
            "// ==================================================================\n" +
            "//\n" +
            "//    Standard POV-Ray benchmark version 2.03 Scene File Version\n" +
            "//\n" +
            "// This is the official POV-Ray benchmark scene.  It is designed\n" +
            "// to test a variety of POV-Ray features and should render in a\n" +
            "// reasonable amount of time on current machines.  Note that the\n" +
            "// radiosity feature is still experimental and not very suitable for\n" +
            "// comparing results of different versions, therefore it is turned\n" +
            "// off by default.\n" +
            "//\n" +
            "// Please log all changes made to this file below.\n" +
            "//\n" +
            "// Also, please make sure the distribution copy of this file\n" +
            "// (`distribution/scenes/advanced/benchmark/benchmark.pov`) remains in\n" +
            "// sync with the inbuilt copy (`source/backend/control/benchmark_pov.cpp`)\n" +
            "// and the version number in `source/backend/control/benchmark.cpp`.\n" +
            "//\n" +
            "// Note that only results generated with the above options and the\n" +
            "// unchanged scene file are allowed to be published as 'official\n" +
            "// POV-Ray benchmark results'.  Feel free to do additional tests, but\n" +
            "// make sure the differences are made clear when publishing them.\n" +
            "//\n" +
            "// When publishing results, be sure to quote the exact version of the\n" +
            "// benchmark scene used (2.03 Scene File Version), and the exact\n" +
            "// version of POV-Ray.\n" +
            "//\n" +
            "// ==================================================================\n" +
            "//\n" +
            "// Change history\n" +
            "// --------------\n" +
            "//\n" +
            "// Nov. 2001   Initial release (version 3.5.0)\n" +
            "// Jan. 2002   using 'max()' instead of '&' in isosurface\n" +
            "// Apr. 2002   changed max_gradient of isosurface (new ver is 1.01)\n" +
            "// Jun. 2002   added photons pass_through to clouds (new ver is 1.02)\n" +
            "// Dec. 2010   made ready for v3.7 release (new ver is 2.00)\n" +
            "// Dec. 2010   last minute changes re: assumed_gamma (kept version the same)\n" +
            "// Oct. 2012   allow to run without installation (same ver : 2.00)\n" +
            "// Jan. 2013   change version to 2.01 to differentiate from beta.\n" +
            "// Feb  2013   Updated for v3.7\n" +
            "// Nov. 2017   Re-synced distribution copy with built-in copy (new ver is 2.02)\n" +
            "// Nov. 2017   Updated for v3.8 (new ver is 2.03)\n" +
            "//\n" +
            "// ==================================================================\n" +
            "//\n" +
            "// Suggested command line options if not using an INI file:\n" +
            "//\n" +
            "// -w512 -h512 +a0.3 +v -d -f -x\n" +
            "//\n" +
            "// The following INI options are used when the 'Run Benchmark' command\n" +
            "// is chosen on versions of POV-Ray that support the built-in version.\n" +
            "//\n" +
            "// All_Console=On\n" +
            "// All_File=\n" +
            "// Antialias_Depth=3\n" +
            "// Antialias=On\n" +
            "// Antialias_Gamma=2.5\n" +
            "// Antialias_Threshold=0.3\n" +
            "// Bits_Per_Color=8\n" +
            "// Bounding=On\n" +
            "// Bounding_Method=1\n" +
            "// Bounding_Threshold=3\n" +
            "// Clock=0\n" +
            "// Continue_Trace=Off\n" +
            "// Clockless_Animation=off\n" +
            "// Cyclic_Animation=Off\n" +
            "// Debug_Console=On\n" +
            "// Display=Off\n" +
            "// Display_Gamma=2.2\n" +
            "// Dither=off\n" +
            "// End_Column=1\n" +
            "// End_Row=1\n" +
            "// Fatal_Console=On\n" +
            "// Fatal_Error_Command=\n" +
            "// Fatal_Error_Return=I\n" +
            "// Field_Render=Off\n" +
            "// Final_Clock=1\n" +
            "// Final_Frame=1\n" +
            "// Grayscale_Output=off\n" +
            "// Height=512\n" +
            "// High_Reproducibility=off\n" +
            "// Initial_Clock=0\n" +
            "// Initial_Frame=1\n" +
            "// Include_Header=\n" +
            "// Input_File_Name=benchmark.pov\n" +
            "// Jitter_Amount=0.3\n" +
            "// Jitter=On\n" +
            "// Light_Buffer=On\n" +
            "// Odd_Field=Off\n" +
            "// Output_Alpha=Off\n" +
            "// Output_File_Name=\n" +
            "// Output_File_Type=n\n" +
            "// Output_To_File=Off\n" +
            "// Palette=3\n" +
            "// Pause_When_Done=Off\n" +
            "// Post_Frame_Command=\n" +
            "// Post_Frame_Return=I\n" +
            "// Post_Scene_Command=\n" +
            "// Post_Scene_Return=I\n" +
            "// Preview_End_Size=1\n" +
            "// Preview_Start_Size=1\n" +
            "// Pre_Frame_Command=\n" +
            "// Pre_Frame_Return=I\n" +
            "// Pre_Scene_Command=\n" +
            "// Pre_Scene_Return=I\n" +
            "// Quality=9\n" +
            "// Radiosity_From_File=off\n" +
            "// Radiosity_To_File=off\n" +
            "// Radiosity_Vain_Pretrace=on\n" +
            "// Real_Time_Raytracing=off\n" +
            "// Remove_Bounds=On\n" +
            "// Render_Block_Size=16\n" +
            "// Render_Block_Step=0\n" +
            "// Render_Console=On\n" +
            "// Render_Pattern=0\n" +
            "// Sampling_Method=1\n" +
            "// Split_Unions=Off\n" +
            "// Start_Column=0\n" +
            "// Start_Row=0\n" +
            "// Statistic_Console=On\n" +
            "// Subset_End_Frame=1\n" +
            "// Subset_Start_Frame=1\n" +
            "// Test_Abort_Count=0\n" +
            "// Test_Abort=Off\n" +
            "// User_Abort_Command=\n" +
            "// User_Abort_Return=I\n" +
            "// Verbose=On\n" +
            "// Version=3.8\n" +
            "// Warning_Console=On\n" +
            "// Width=512\n" +
            "//\n" +
            "// ==================================================================\n" +
            "\n" +
            "#version 3.8;\n" +
            "\n" +
            "#default { texture { finish { ambient 0.02 diffuse 1 }}}\n" +
            "\n" +
            "#declare use_radiosity = false;\n" +
            "\n" +
            "#declare use_photons = true;\n" +
            "#declare use_area_light = true;\n" +
            "\n" +
            "#declare show_clouds = true;\n" +
            "#declare show_objects = true;\n" +
            "\n" +
            "#declare Rad = 50000;\n" +
            "\n" +
            "global_settings {\n" +
            "   assumed_gamma 1.0\n" +
            "   max_trace_level 12\n" +
            "\n" +
            "   #if (use_radiosity=true)\n" +
            "\n" +
            "      radiosity {\n" +
            "         pretrace_start 0.08\n" +
            "         pretrace_end 0.01\n" +
            "         count 80\n" +
            "\n" +
            "         nearest_count 5\n" +
            "         error_bound 0.5\n" +
            "         recursion_limit 1\n" +
            "\n" +
            "         low_error_factor .5\n" +
            "         gray_threshold 0.0\n" +
            "         minimum_reuse 0.015\n" +
            "         brightness 0.7\n" +
            "\n" +
            "         adc_bailout 0.01/2\n" +
            "\n" +
            "         normal on\n" +
            "      }\n" +
            "\n" +
            "   #end\n" +
            "\n" +
            "   #if (use_photons=true)\n" +
            "      photons { spacing 0.007 }\n" +
            "   #end\n" +
            "\n" +
            "}\n" +
            "\n" +
            "//====================================================================================\n" +
            "\n" +
            "// This scene uses a non-standard camera set-up. \n" +
            "// (See CAMERA in the included documentation for details.) \n" +
            "// If you are new to POV-Ray, you might want to try a different demo scene.\n" +
            "camera {\n" +
            "   location  <3.2, 3.2, 1.8>\n" +
            "   direction y\n" +
            "   sky       z\n" +
            "   up        z\n" +
            "   right     -x*(image_width/image_height) // keep propotions with any aspect ratio\n" +
            "   look_at   <-1, -1, 0.9>\n" +
            "   angle     45\n" +
            "}\n" +
            "\n" +
            "light_source {\n" +
            "   <-0.7, 0.83, 0.24>*150000\n" +
            "   color rgb <3.43,2.87,1.95>\n" +
            "   #if (use_area_light=true)\n" +
            "      area_light 4000*x 4000*y  4,4\n" +
            "      jitter\n" +
            "      orient\n" +
            "      circular\n" +
            "   #end\n" +
            "\n" +
            "   media_attenuation on\n" +
            "   media_interaction on\n" +
            "\n" +
            "   photons {\n" +
            "      reflection on\n" +
            "      refraction on\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#if (use_radiosity=false)\n" +
            "   light_source {\n" +
            "      <0.9, -0.6, 0.5>*150000\n" +
            "      color rgb 0.35\n" +
            "\n" +
            "      shadowless\n" +
            "   }\n" +
            "#end\n" +
            "\n" +
            "fog{\n" +
            "   fog_type 2\n" +
            "   fog_alt 1.5\n" +
            "   fog_offset 0\n" +
            "   color rgbt <0.75, 0.80, 0.86, 0.2>\n" +
            "   distance 400\n" +
            "   up z\n" +
            "}\n" +
            "\n" +
            "\n" +
            "//====================================================================================\n" +
            "\n" +
            "// Copied from functions.inc for Oct 2012\n" +
            "#declare f_ridged_mf = function { internal(59) }\n" +
            "// Parameters: x, y, z\n" +
            "   // Six extra parameters required:\n" +
            "   // 1. H \n" +
            "   // 2. Lacunarity \n" +
            "   // 3. octaves\n" +
            "   // 4. offset \n" +
            "   // 5. Gain \n" +
            "   // 6. noise\n" +
            "\n" +
            "#declare RMF = function{ f_ridged_mf(x, y, z, 0.07, 2.2,  7, 0.6, 0.9, 1)}\n" +
            "\n" +
            "#declare M_Watx4 =\n" +
            "material {\n" +
            "   texture {\n" +
            "      pigment { color rgbt <0.21, 0.20, 0.3, 0.96> }\n" +
            "      finish {\n" +
            "         diffuse 0.0\n" +
            "         ambient 0.0\n" +
            "\n" +
            "         reflection {\n" +
            "            0.1, 0.95\n" +
            "            fresnel on\n" +
            "            exponent 0.8\n" +
            "         }\n" +
            "\n" +
            "         conserve_energy\n" +
            "\n" +
            "         specular 0.1\n" +
            "         roughness 0.007\n" +
            "         metallic\n" +
            "      }\n" +
            "      normal{\n" +
            "         function { RMF(x, y, z) } 0.2\n" +
            "         scale 0.07\n" +
            "      }\n" +
            "   }\n" +
            "   interior {\n" +
            "      ior 1.31\n" +
            "      fade_distance 0.8\n" +
            "      fade_power 1001.0\n" +
            "      fade_color <0.02, 0.20, 0.06>\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "box {              // --- Water ---\n" +
            "   <-1.95,  -1.65, 0.42>, < 1.95,  1.65, -5.5>\n" +
            "\n" +
            "   material { M_Watx4 }\n" +
            "   hollow on\n" +
            "\n" +
            "   photons { collect off }\n" +
            "}\n" +
            "\n" +
            "#declare fn_RMF = function{ f_ridged_mf(x, y, z, 0.1, 3.1, 8 ,0.7, 0.8, 2) }\n" +
            "\n" +
            "\n" +
            "plane {            // --- floor ---\n" +
            "   z, -0.3\n" +
            "\n" +
            "   texture {\n" +
            "      pigment { color rgb <1.0, 0.85, 0.6> }\n" +
            "      finish {\n" +
            "         diffuse 0.7\n" +
            "         specular 0.1\n" +
            "      }\n" +
            "      normal {\n" +
            "         function { fn_RMF(x, y, z) } 0.3\n" +
            "         scale 8\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   clipped_by {\n" +
            "      box { <-1.95,  -1.65, 1>, < 1.95,  1.65, -1> inverse }\n" +
            "   }\n" +
            "\n" +
            "   photons { collect off }\n" +
            "}\n" +
            "\n" +
            "\n" +
            "isosurface {\n" +
            "   function {\n" +
            "      z - fn_RMF(x, y, z)*0.07\n" +
            "   }\n" +
            "\n" +
            "   max_gradient 1.3\n" +
            "\n" +
            "   contained_by { box { <-15, -15, 0.0>, <15, 15, 0.2> } }\n" +
            "\n" +
            "   texture {\n" +
            "      pigment { color rgb <1.0, 0.85, 0.6> }\n" +
            "      finish {\n" +
            "         diffuse 0.7\n" +
            "         specular 0.1\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   scale 8\n" +
            "   translate -0.16*z\n" +
            "\n" +
            "   clipped_by {\n" +
            "      box { <-1.95,  -1.65, 1>, < 1.95,  1.65, -1> inverse }\n" +
            "   }\n" +
            "\n" +
            "   photons { collect off }\n" +
            "}\n" +
            "\n" +
            "\n" +
            "// ====================================================================================\n" +
            "\n" +
            "\n" +
            "\n" +
            "sphere {           // --- Sky ---\n" +
            "   <0, 0, 0>, 1\n" +
            "   texture {\n" +
            "      pigment {\n" +
            "         gradient z\n" +
            "         pigment_map {\n" +
            "            [0.00 color rgb <0.6667, 0.7255, 0.7725>]\n" +
            "            [0.19\n" +
            "               spherical\n" +
            "               color_map {\n" +
            "                  [0.08 color rgb <0.33, 0.37, 0.90> ]\n" +
            "                  [0.14 color rgb <0.3210, 0.53, 0.9259> ]\n" +
            "                  [0.26 color rgb <0.3610, 0.57, 0.9259> ]\n" +
            "                  [0.50 color rgb < 0.880, 0.935, 0.976 > ]\n" +
            "               }\n" +
            "               scale 1.8\n" +
            "               translate <-0.7, 0.7, 0.24>\n" +
            "            ]\n" +
            "         }\n" +
            "      }\n" +
            "      finish {\n" +
            "         diffuse 0\n" +
            "         emission 1\n" +
            "      }\n" +
            "   }\n" +
            "   scale Rad*<20, 20, 4>\n" +
            "   translate -2*z\n" +
            "   no_shadow\n" +
            "   hollow on\n" +
            "\n" +
            "   photons { collect off pass_through }\n" +
            "}\n" +
            "\n" +
            "#if (show_clouds)\n" +
            "\n" +
            "// from mick\n" +
            "\n" +
            "difference {\n" +
            "   sphere { 0,Rad}\n" +
            "   sphere {0,Rad-15000}\n" +
            "   material{\n" +
            "      texture{\n" +
            "         pigment{ rgbf 1 }\n" +
            "         finish {\n" +
            "            ambient 0\n" +
            "            diffuse 0\n" +
            "         }\n" +
            "      }\n" +
            "      interior{\n" +
            "         media{\n" +
            "            scattering {2,<.013,.012,.008>/1.3 extinction 1/1.3 }\n" +
            "            method 3\n" +
            "            samples 7,7\n" +
            "            intervals 1\n" +
            "\n" +
            "            density { // one\n" +
            "               wrinkles\n" +
            "               ramp_wave\n" +
            "\n" +
            "               noise_generator 1\n" +
            "\n" +
            "               color_map {\n" +
            "                  [0 rgb 0]\n" +
            "                  [0.5 rgb 0]\n" +
            "                  [0.7 rgb 0.275]\n" +
            "                  [1 rgb 0.475]\n" +
            "               } // color_map\n" +
            "\n" +
            "               scale <10000,9000,5000>/3\n" +
            "               rotate z*29\n" +
            "               translate <1000,0,Rad-30000>\n" +
            "            } // density\n" +
            "\n" +
            "            density { // two\n" +
            "               marble\n" +
            "               warp { turbulence 1.65 octaves 7 }\n" +
            "               noise_generator 1\n" +
            "\n" +
            "               color_map {\n" +
            "                  [0 rgb 0]\n" +
            "                  [0.4 rgb 0]\n" +
            "                  [0.85 rgb 0.25]\n" +
            "                  [1 rgb 0.5]\n" +
            "               } // color_map\n" +
            "\n" +
            "               scale <10000,7500,5000>*5\n" +
            "               rotate z*-25\n" +
            "               translate <0,0,Rad-30000>\n" +
            "            } // density\n" +
            "\n" +
            "         } // media\n" +
            "      } // interior\n" +
            "   } // material\n" +
            "   hollow\n" +
            "\n" +
            "   rotate z*70\n" +
            "   rotate y*15\n" +
            "   translate <0,0,32000-Rad>\n" +
            "   rotate -102*z\n" +
            "\n" +
            "   scale <1,1,0.4>\n" +
            "\n" +
            "   photons { collect off pass_through }\n" +
            "\n" +
            "} // difference\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "// ====================================================================================\n" +
            "\n" +
            "\n" +
            "#declare Metal_Texture =\n" +
            "texture {\n" +
            "   pigment { color rgb <0.65, 0.55, 0.5> }\n" +
            "   finish {\n" +
            "      ambient 0.0\n" +
            "      diffuse 0.15\n" +
            "      specular 0.3\n" +
            "      metallic\n" +
            "      roughness 0.01\n" +
            "      reflection {\n" +
            "         0.8\n" +
            "         metallic\n" +
            "      }\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Stone_Tex =\n" +
            "texture {\n" +
            "   pigment {\n" +
            "      crackle\n" +
            "      pigment_map {\n" +
            "         [0.03\n" +
            "            bozo\n" +
            "            color_map {\n" +
            "               [0 color rgb <0.2, 0.14, 0.05>]\n" +
            "               [1 color rgb <0.2, 0.14, 0.05>]\n" +
            "            }\n" +
            "            warp { turbulence 0.6 }\n" +
            "         ]\n" +
            "         [0.055\n" +
            "            granite\n" +
            "            color_map {\n" +
            "               [0.0 color rgb <1, 0.95, 0.9>]\n" +
            "               [0.5 color rgb <0.6, 0.5, 0.52>]\n" +
            "               [1.0 color rgb <0.9, 0.8, 0.7>]\n" +
            "            }\n" +
            "            warp { turbulence 0.4 lambda 2.4 octaves 8 }\n" +
            "            scale 0.5\n" +
            "         ]\n" +
            "      }\n" +
            "\n" +
            "      warp { turbulence 0.72 lambda 2.25 omega 0.53 octaves 9}\n" +
            "\n" +
            "      scale 0.3\n" +
            "   }\n" +
            "   finish {\n" +
            "      diffuse 0.55\n" +
            "      specular 0.1\n" +
            "   }\n" +
            "   normal {\n" +
            "      granite 0.15\n" +
            "      scale 0.06\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Stone_Tex2 =\n" +
            "texture {\n" +
            "   pigment {\n" +
            "      crackle\n" +
            "      pigment_map {\n" +
            "         [0.03\n" +
            "            bozo\n" +
            "            color_map {\n" +
            "               [0 color rgb <0.1, 0.08, 0.2>]\n" +
            "               [1 color rgb <0.1, 0.08, 0.2>]\n" +
            "            }\n" +
            "            warp { turbulence 0.6 }\n" +
            "         ]\n" +
            "         [0.055\n" +
            "            granite\n" +
            "            color_map {\n" +
            "               [0.0 color rgb <1, 0.95, 0.9>]\n" +
            "               [0.5 color rgb <0.6, 0.5, 0.52>]\n" +
            "               [1.0 color rgb <0.9, 0.8, 0.7>]\n" +
            "            }\n" +
            "            warp { turbulence 0.4 lambda 2.4 octaves 8 }\n" +
            "            scale 1.2\n" +
            "         ]\n" +
            "      }\n" +
            "\n" +
            "      warp { turbulence 0.55 lambda 2.25 omega 0.53 octaves 9 }\n" +
            "\n" +
            "      scale 0.24\n" +
            "   }\n" +
            "   finish {\n" +
            "      diffuse 0.55\n" +
            "      specular 0.1\n" +
            "   }\n" +
            "   normal {\n" +
            "      granite 0.15\n" +
            "      scale 0.06\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Stone_Tex3 =\n" +
            "texture {\n" +
            "   pigment {\n" +
            "      agate\n" +
            "      pigment_map {\n" +
            "         [0.3\n" +
            "            crackle\n" +
            "            color_map {\n" +
            "               [0.1 color rgb <0.3, 0.28, 0.4>]\n" +
            "               [0.2 color rgb <0.8, 0.7, 0.4>]\n" +
            "            }\n" +
            "            warp { turbulence 0.5 lambda 2.2 omega 0.52 octaves 8 }\n" +
            "            scale 0.3\n" +
            "         ]\n" +
            "         [0.5\n" +
            "            granite\n" +
            "            color_map {\n" +
            "               [0.0 color rgb <1, 0.95, 0.9>]\n" +
            "               [0.5 color rgb <0.3, 0.6, 0.52>]\n" +
            "               [1.0 color rgb <0.3, 0.8, 0.7>]\n" +
            "            }\n" +
            "            warp { turbulence 0.4 lambda 2.4 octaves 8 }\n" +
            "         ]\n" +
            "      }\n" +
            "\n" +
            "      warp { turbulence 0.55 }\n" +
            "\n" +
            "      scale 0.24\n" +
            "   }\n" +
            "   finish {\n" +
            "      diffuse 0.55\n" +
            "      specular 0.1\n" +
            "   }\n" +
            "   normal {\n" +
            "      granite 0.15\n" +
            "      scale 0.06\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Mat_Glass =\n" +
            "material {\n" +
            "   texture {\n" +
            "      pigment { color rgbt 1 }\n" +
            "      finish {\n" +
            "         diffuse 0\n" +
            "         ambient 0\n" +
            "         specular 0.6\n" +
            "         metallic 0.5\n" +
            "         roughness 0.005\n" +
            "\n" +
            "         reflection {\n" +
            "            0.05, 0.95\n" +
            "            fresnel on\n" +
            "         }\n" +
            "\n" +
            "         conserve_energy\n" +
            "      }\n" +
            "   }\n" +
            "   interior {\n" +
            "      ior 1.5\n" +
            "      fade_distance 0.12\n" +
            "      fade_power 1001\n" +
            "      fade_color <0.6, 0.5, 0.7>\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "\n" +
            "#declare Socket =\n" +
            "union {\n" +
            "   difference {\n" +
            "      cylinder { -5*z, -0.04*z, 0.8 }\n" +
            "      cylinder { -6*z, 0, 0.3 }\n" +
            "\n" +
            "      #declare Cnt = 0;\n" +
            "\n" +
            "      #while (Cnt<360)\n" +
            "\n" +
            "         merge {\n" +
            "            cylinder { < 0.0,  0.0, -0.24>, < 1.0,  0.0, -0.24>, 0.1 }\n" +
            "            box { < 0.0,  -0.1, -0.24>, < 1.0,  0.1, -6> }\n" +
            "\n" +
            "            rotate Cnt*z\n" +
            "         }\n" +
            "\n" +
            "         #declare Cnt = Cnt+30;\n" +
            "      #end\n" +
            "   }\n" +
            "\n" +
            "   #declare Cnt = 0;\n" +
            "\n" +
            "   #while (Cnt<360)\n" +
            "\n" +
            "      union {\n" +
            "         cylinder { < 0.8,  0.0, -0.04>, < 0.8,  0.0, -5>, 0.05 }\n" +
            "         cylinder { < 0.8,  0.0, -0.04>, < 0.8,  0.0, -0.01>, 0.07 }\n" +
            "\n" +
            "         rotate 15*z\n" +
            "         rotate Cnt*z\n" +
            "      }\n" +
            "\n" +
            "      #declare Cnt = Cnt+30;\n" +
            "   #end\n" +
            "\n" +
            "   cylinder { -0.04*z, 0, 0.86 }\n" +
            "   torus {\n" +
            "      0.83, 0.03\n" +
            "      rotate 90*x\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Pos1 = < 0.0,  0.0, 0.6>;\n" +
            "#declare Pos2 = <-2.4, -0.8, 1.0>;\n" +
            "#declare Pos3 = <-1.4, -2.8, 1.3>;\n" +
            "#declare Pos4 = < 1.4,  0.6, 0.5>;\n" +
            "\n" +
            "#declare Pos5 = <-10, -5, 1.5>;\n" +
            "\n" +
            "object { Socket translate Pos1 texture { Stone_Tex } }\n" +
            "\n" +
            "object { Socket translate Pos2 texture { Stone_Tex } }\n" +
            "\n" +
            "object { Socket scale 0.8 translate Pos3 texture { Stone_Tex } }\n" +
            "\n" +
            "object { Socket scale 0.4 translate Pos4 texture { Stone_Tex } }\n" +
            "\n" +
            "object { Socket scale 2 translate Pos5 texture { Stone_Tex } }\n" +
            "\n" +
            "difference {\n" +
            "   box { <-2.0,  -1.7, 0.5>, < 2.0,  1.7, -6> }\n" +
            "   box { <-1.9,  -1.6, 1.0>, < 1.9,  1.6, -5> }\n" +
            "\n" +
            "   texture {\n" +
            "      Stone_Tex2\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "#declare POV_Text =\n" +
            "text {\n" +
            "   internal 1 // ttf \"timrom.ttf\"\n" +
            "   \"POV-Ray\"\n" +
            "   0.25,0\n" +
            "   scale 0.3\n" +
            "   rotate 90*x\n" +
            "   rotate -90*z\n" +
            "}\n" +
            "\n" +
            "#declare Version_Text =\n" +
            "text {\n" +
            "   internal 1 // ttf \"timrom.ttf\"\n" +
            "   \"Version 3.8\"\n" +
            "   0.25,0\n" +
            "   scale 0.3\n" +
            "   rotate 90*x\n" +
            "   rotate -90*z\n" +
            "}\n" +
            "\n" +
            "object {\n" +
            "   POV_Text\n" +
            "   translate <-1.97,  0.995, 0.575>\n" +
            "   texture { Stone_Tex2 }\n" +
            "}\n" +
            "\n" +
            "object {\n" +
            "   Version_Text\n" +
            "   rotate 90*z\n" +
            "   translate <-0.5, -1.5, 0.575>\n" +
            "   texture { Stone_Tex2 }\n" +
            "}\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "\n" +
            "height_field {\n" +
            "\n" +
            "   function 300,300 {\n" +
            "      pigment {\n" +
            "         function { 1-(min(pow(x*x + y*y, 0.25), 1) -0.0001) }\n" +
            "\n" +
            "         color_map {\n" +
            "            [0.0 rgb 0.0]\n" +
            "            [1.0 rgb 1.0]\n" +
            "         }\n" +
            "\n" +
            "         translate <0.5,0.5,0>\n" +
            "\n" +
            "         scale 0.45\n" +
            "\n" +
            "         warp { turbulence 0.455 }\n" +
            "\n" +
            "         scale 3\n" +
            "         warp { turbulence 0.2 lambda 2.2 octaves 8 }\n" +
            "         scale 1/3\n" +
            "\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   water_level 0.02\n" +
            "\n" +
            "   rotate 90*x\n" +
            "\n" +
            "   rotate 43*z\n" +
            "\n" +
            "   scale <5, 5, 1.3>\n" +
            "   scale 2.6\n" +
            "\n" +
            "   texture {\n" +
            "      pigment {\n" +
            "         bozo\n" +
            "         color_map {\n" +
            "            [0.40 color rgb <0.6, 0.6, 0.7>*0.6]\n" +
            "            [0.58 color rgb <0.9, 0.6, 0.3>*0.6]\n" +
            "            [0.62 color rgb <0.2, 0.6, 0.1>*0.4]\n" +
            "         }\n" +
            "         warp { turbulence 0.4 }\n" +
            "         scale <0.2, 0.2, 3>\n" +
            "      }\n" +
            "      finish {\n" +
            "         diffuse 0.6\n" +
            "         specular 0.2\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   translate <-18, -13, -0.4>\n" +
            "}\n" +
            "\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "// ---------- Pos1 ----------\n" +
            "\n" +
            "difference {\n" +
            "   cylinder { -0.0*z, 0.15*z, 0.7 }\n" +
            "   cylinder { -0.1*z, 0.25*z, 0.68 }\n" +
            "\n" +
            "   texture { Metal_Texture }\n" +
            "\n" +
            "   translate 0.6*z\n" +
            "\n" +
            "   photons { target reflection on }\n" +
            "}\n" +
            "\n" +
            "#declare fn_pigm =\n" +
            "function {\n" +
            "   pigment {\n" +
            "      bozo\n" +
            "      poly_wave 2\n" +
            "      color_map {\n" +
            "         [0 rgb 0][1 rgb 1]\n" +
            "      }\n" +
            "      warp {  turbulence 0.4 lambda 2.3 omega 0.52 }\n" +
            "\n" +
            "      scale 0.2\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "\n" +
            "isosurface {\n" +
            "   function {\n" +
            "      (max(sqrt(x*x + y*y)-0.25, z-0.7))\n" +
            "\n" +
            "      - fn_pigm(x, y, z).gray*0.07\n" +
            "\n" +
            "   }\n" +
            "\n" +
            "   max_gradient 2.4\n" +
            "\n" +
            "   contained_by { box { <-0.35, -0.35, 0.0>, <0.35, 0.35, 0.8> } }\n" +
            "\n" +
            "   texture {\n" +
            "      pigment { color rgb <1, 0.45, 0.2> }\n" +
            "      finish {\n" +
            "         diffuse 0.6\n" +
            "         specular 0.2\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   translate Pos1\n" +
            "}\n" +
            "\n" +
            "// Copied from logo.inc for Oct 2012\n" +
            "// The original version is made of various objects.\n" +
            "#declare Povray_Logo =\n" +
            "merge {\n" +
            "   sphere {2*y, 1}\n" +
            "   difference {\n" +
            "      cone {2*y, 1, -4*y, 0}\n" +
            "      sphere {2*y, 1.4 scale <1,1,2>}\n" +
            "   }\n" +
            "   difference {\n" +
            "      sphere {0, 1 scale <2.6, 2.2, 1>}\n" +
            "      sphere {0, 1 scale <2.3, 1.8, 2> translate <-0.35, 0, 0>}\n" +
            "      rotate z*30 translate 2*y\n" +
            "   }\n" +
            "   rotate <0, 0, -25>\n" +
            "   translate <-0.5,-0.35,0>\n" +
            "   scale 1/4\n" +
            "}\n" +
            "\n" +
            "\n" +
            "object {\n" +
            "   Povray_Logo\n" +
            "\n" +
            "   rotate 90*x\n" +
            "   scale 0.4\n" +
            "   translate -0.2*y\n" +
            "\n" +
            "   texture {\n" +
            "      pigment { color rgb <0.65, 0.55, 0.9> }\n" +
            "      finish {\n" +
            "         ambient 0.0\n" +
            "         diffuse 0.15\n" +
            "         specular 0.3\n" +
            "         metallic\n" +
            "         roughness 0.01\n" +
            "         reflection {\n" +
            "            0.8\n" +
            "            metallic\n" +
            "         }\n" +
            "      }\n" +
            "      normal {\n" +
            "         bumps 0.3\n" +
            "         scale 0.3\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   rotate -25*z\n" +
            "\n" +
            "   translate 0.96*z\n" +
            "\n" +
            "   translate Pos1\n" +
            "}\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "// ---------- Pos2 ----------\n" +
            "\n" +
            "#declare rd = seed(45);\n" +
            "\n" +
            "union {\n" +
            "\n" +
            "   #declare Cnt = 0;\n" +
            "\n" +
            "   #while (Cnt<360)\n" +
            "\n" +
            "      superellipsoid {\n" +
            "         <rand(rd)*2, rand(rd)*2>\n" +
            "         texture { Metal_Texture }\n" +
            "         scale 0.12\n" +
            "         translate <0.6, 0.0, 0.12>\n" +
            "         rotate (Cnt+30)*z\n" +
            "      }\n" +
            "\n" +
            "      julia_fractal {\n" +
            "         < rand(rd), rand(rd)*0.6, -0.54, 0.2 >\n" +
            "         quaternion\n" +
            "         max_iteration 7\n" +
            "         precision 500\n" +
            "         scale 0.12\n" +
            "         translate <0.6, 0.0, 0.1>\n" +
            "         rotate Cnt*z\n" +
            "\n" +
            "         texture {\n" +
            "            pigment { color rgb <1, 0.4, 0.8> }\n" +
            "            finish {\n" +
            "               ambient 0\n" +
            "               diffuse 0.6\n" +
            "               specular 0.2\n" +
            "               reflection 0.2\n" +
            "            }\n" +
            "         }\n" +
            "      }\n" +
            "\n" +
            "      #declare Cnt = Cnt+60;\n" +
            "   #end\n" +
            "\n" +
            "   translate Pos2\n" +
            "}\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "// ---------- Pos3 ----------\n" +
            "\n" +
            "sphere {\n" +
            "   0, 0.24\n" +
            "\n" +
            "   translate 0.24*z\n" +
            "\n" +
            "   material { Mat_Glass }\n" +
            "\n" +
            "   photons { target reflection on refraction on }\n" +
            "\n" +
            "   translate Pos3\n" +
            "}\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "\n" +
            "// ---------- Pos4 ----------\n" +
            "\n" +
            "\n" +
            "// from ingo\n" +
            "\n" +
            "#declare Letter =\n" +
            "text {\n" +
            "   internal 1 // ttf \"timrom.ttf\"\n" +
            "   \"X\"\n" +
            "   1,0\n" +
            "   scale <1/0.7,1/0.66,1>\n" +
            "   translate <0,0,-0.5>\n" +
            "}\n" +
            "\n" +
            "#declare xPigm =\n" +
            "function {\n" +
            "   pigment {\n" +
            "      object {\n" +
            "         Letter\n" +
            "         pigment {rgb 1}\n" +
            "         pigment {rgb 0}\n" +
            "      }\n" +
            "      warp {repeat x}\n" +
            "      warp {repeat y}\n" +
            "      scale 1.00002\n" +
            "      translate < 0.000001,-0.00001, 0>\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare XsinPigm =\n" +
            "function {\n" +
            "   pigment {\n" +
            "      function {xPigm(sin(x),pow(sin(y),2),z).gray}\n" +
            "   }\n" +
            "}\n" +
            "\n" +
            "#declare Fn_Obj =\n" +
            "difference {\n" +
            "   cylinder {\n" +
            "      -2*y, 2*y, 2\n" +
            "      pigment {\n" +
            "         function{XsinPigm(x,y,z).gray}\n" +
            "         warp {planar}\n" +
            "         scale <0.5/pi, 1, 1>*0.5\n" +
            "         warp {\n" +
            "            cylindrical\n" +
            "            orientation z\n" +
            "            dist_exp 1\n" +
            "         }\n" +
            "         colour_map {\n" +
            "            [0, rgb 1]\n" +
            "            [1, rgbf 1]\n" +
            "         }\n" +
            "      }\n" +
            "      finish {\n" +
            "        diffuse 0.6\n" +
            "        specular 0.4\n" +
            "      }\n" +
            "   }\n" +
            "   cylinder {\n" +
            "      -1.9*y, 2.1*y, 1.9\n" +
            "      pigment {rgbf 1}\n" +
            "      finish {\n" +
            "        diffuse 0.6\n" +
            "        specular 0.4\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   translate 1.96*y\n" +
            "   rotate 90*x\n" +
            "   scale 0.12\n" +
            "}\n" +
            "\n" +
            "object {\n" +
            "   Fn_Obj\n" +
            "   translate Pos4\n" +
            "}\n" +
            "\n" +
            "#end\n" +
            "\n" +
            "\n" +
            "#if (show_objects)\n" +
            "\n" +
            "\n" +
            "// ---------- Pos5 ----------\n" +
            "\n" +
            "\n" +
            "// from ingo\n" +
            "\n" +
            "#macro BuildWriteMesh2(VecArr, NormArr, UVArr, U, V)\n" +
            "\n" +
            "   #debug concat(\"\\n\\n Building mesh2: \\n   - vertex_vectors\\n\")\n" +
            "   #local NumVertices = dimension_size(VecArr,1);\n" +
            "   mesh2 {\n" +
            "      vertex_vectors {\n" +
            "         NumVertices\n" +
            "         #local I = 0;\n" +
            "         #while (I<NumVertices)\n" +
            "            VecArr[I]\n" +
            "            #local I = I+1;\n" +
            "         #end\n" +
            "      }\n" +
            "\n" +
            "      #debug concat(\"   - normal_vectors\\n\")\n" +
            "      #local NumVertices = dimension_size(NormArr,1);\n" +
            "      normal_vectors {\n" +
            "         NumVertices\n" +
            "         #local I = 0;\n" +
            "         #while (I<NumVertices)\n" +
            "            NormArr[I]\n" +
            "            #local I = I+1;\n" +
            "         #end\n" +
            "      }\n" +
            "\n" +
            "      #debug concat(\"   - uv_vectors\\n\")\n" +
            "      #local NumVertices = dimension_size(NormArr,1);\n" +
            "      uv_vectors {\n" +
            "         NumVertices\n" +
            "         #local I = 0;\n" +
            "         #while (I<NumVertices)\n" +
            "            UVArr[I]\n" +
            "            #local I = I+1;\n" +
            "         #end\n" +
            "      }\n" +
            "\n" +
            "      #debug concat(\"   - face_indices\\n\")\n" +
            "      #declare NumFaces = U*V*2;\n" +
            "      face_indices {\n" +
            "         NumFaces\n" +
            "         #local I = 0;\n" +
            "         #local H = 0;\n" +
            "         #while (I<V)\n" +
            "            #local J = 0;\n" +
            "            #while (J<U)\n" +
            "               #local Ind = (I*U)+I+J;\n" +
            "               <Ind, Ind+1, Ind+U+2>, <Ind, Ind+U+1, Ind+U+2>\n" +
            "               #local J = J+1;\n" +
            "               #local H = H+1;\n" +
            "            #end\n" +
            "            #local I = I+1;\n" +
            "         #end\n" +
            "      }\n" +
            "   }\n" +
            "#end\n" +
            "\n" +
            "#macro FnA(X)\n" +
            "   #if (X<0.13)\n" +
            "      0.5+sin(X*14)*0.4\n" +
            "   #else\n" +
            "      0.5+sin((X-0.13)*7.2)*0.3\n" +
            "   #end\n" +
            "#end\n" +
            "\n" +
            "\n" +
            "// Build a two-dimensional array with vectors and normals retrieved from a function macro\n" +
            "// ResSpl: the amount of vectors to get from the macro\n" +
            "// based on ingo's code for splines\n" +
            "\n" +
            "#macro L_GetVN(ResSpl)\n" +
            "   #local I = 0;\n" +
            "   #local A = array[ResSpl+1][2]\n" +
            "   #while (I<=ResSpl)\n" +
            "      #local P0 = 0+<FnA(I/ResSpl), I/ResSpl, 0>;\n" +
            "      #if (P0.x=0 & P0.z=0)\n" +
            "         #local P0 = <1e-25,P0.y,1e-25>;\n" +
            "      #end\n" +
            "      #if (I=0)\n" +
            "         #local P1 = 0+<FnA(((I-0.5)/ResSpl)), I/ResSpl, 0>;\n" +
            "         #local P2 = 0+<FnA(((I+0.5)/ResSpl)), I/ResSpl, 0>;\n" +
            "      #else\n" +
            "         #local P1 = P2;\n" +
            "         #local P2 = 0+<FnA(((I+0.5)/ResSpl)), I/ResSpl, 0>;\n" +
            "      #end\n" +
            "      #local P3 = vrotate(P0,<0,1,0>);\n" +
            "      #local P4 = vrotate(P0,<0,-1,0>);\n" +
            "      #local B1 = P4-P0;\n" +
            "      #local B2 = P2-P0;\n" +
            "      #local B3 = P3-P0;\n" +
            "      #local B4 = P1-P0;\n" +
            "      #local N1 = vcross(B1,B2);\n" +
            "      #local N2 = vcross(B2,B3);\n" +
            "      #local N3 = vcross(B3,B4);\n" +
            "      #local N4 = vcross(B4,B1);\n" +
            "      #local N = vnormalize((N1+N2+N3+N4)*-1);\n" +
            "      #local A[I][0] = P0;\n" +
            "      #local A[I][1] = N;\n" +
            "      #local I = I+1;\n" +
            "   #end\n" +
            "   A\n" +
            "#end\n" +
            "\n" +
            "#macro FnLathe (Rot, ResRot, ResSpl)\n" +
            "   #declare VNArr = L_GetVN (ResSpl)\n" +
            "   #local VecArr = array[(ResRot+1)*(ResSpl+1)]\n" +
            "   #local NormArr = array[(ResRot+1)*(ResSpl+1)]\n" +
            "   #local UVArr = array[(ResRot+1)*(ResSpl+1)]\n" +
            "   #local R = Rot/ResRot;\n" +
            "   #local Dim = dimension_size(VNArr,1);\n" +
            "   #local Count = 0;\n" +
            "   #local I = 0;\n" +
            "   #while (I<=ResRot)\n" +
            "      #local J = 0;\n" +
            "      #while (J<Dim)\n" +
            "         #local VecArr[Count] = vrotate(VNArr[J][0],<0,R*I,0>);\n" +
            "         #local NormArr[Count] = vrotate(VNArr[J][1],<0,R*I,0>);\n" +
            "         #local UVArr[Count] = <I/ResRot,J/(Dim-1)>;\n" +
            "         #local J = J+1;\n" +
            "         #local Count = Count+1;\n" +
            "      #end\n" +
            "      #local I = I+1;\n" +
            "   #end\n" +
            "   BuildWriteMesh2(VecArr, NormArr, UVArr, ResSpl, ResRot)\n" +
            "#end\n" +
            "\n" +
            "\n" +
            "#declare MSH = FnLathe(360, 100, 100)\n" +
            "\n" +
            "#declare Obj_Msh =\n" +
            "object {\n" +
            "   MSH\n" +
            "\n" +
            "   uv_mapping\n" +
            "\n" +
            "   texture {\n" +
            "      pigment{\n" +
            "         checker\n" +
            "         color rgb <1.0, 0.7, 0.5>,\n" +
            "         color rgb <0, 0, 0.15>\n" +
            "\n" +
            "         scale 0.05\n" +
            "      }\n" +
            "      finish {\n" +
            "         diffuse 0.7\n" +
            "         specular 0.3\n" +
            "      }\n" +
            "   }\n" +
            "\n" +
            "   rotate 90*x\n" +
            "   scale <1.9, 1.9, 2.8>\n" +
            "\n" +
            "\n" +
            "   translate Pos5\n" +
            "}\n" +
            "\n" +
            "\n" +
            "object { Obj_Msh }\n" +
            "\n" +
            "\n" +
            "#end\n" +
            "";
    }
}