#version 400 core

in vec2 pass_texture_coordinats;
in vec3 pass_surface_normal;
in vec3 to_light_vector;
in vec3 to_camera_vector;

out vec4 out_Color;

uniform sampler2D textureSampler;
uniform vec3 sun_color;

// Material Properties
uniform float material_reflectivity;
uniform float material_shine_damper;
uniform bool material_transparency;

// fog
in float vert_visibility;
uniform vec3 fog_color;

// Scene
uniform float scene_brightness;

void main(void)
{
    vec3 unit_normal = normalize(pass_surface_normal);
    vec3 unit_to_camera_vector = normalize(to_camera_vector);
    vec3 unit_to_light_vector = normalize(to_light_vector);

    // Diffuse light -----------------------------------------------------------
    float brightness = max(dot(unit_normal, unit_to_light_vector), scene_brightness);
    vec3 diffuse_light = brightness * sun_color;

    // Specular light ----------------------------------------------------------
    vec3 reflected_light_direction = reflect(-unit_to_light_vector, unit_normal);
    float specular_factor = pow(max(dot(reflected_light_direction, unit_to_camera_vector), 0.0), material_shine_damper);
    vec3 specular_light = specular_factor * material_reflectivity * sun_color;

    // Texture color -----------------------------------------------------------
    vec4 textureColor = texture(textureSampler, pass_texture_coordinats);

    if (textureColor.a < 0.5 && material_transparency)
    {
      discard;
    }

    // final color -------------------------------------------------------------
    out_Color = vec4(diffuse_light, 1.0) * textureColor + vec4(specular_light, 1.0);
    out_Color = mix(vec4(fog_color, 1.0), out_Color, vert_visibility);
}
